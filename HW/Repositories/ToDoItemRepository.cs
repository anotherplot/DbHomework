using System.Data;
using System.Data.Common;
using DbHomework.Configs;
using DbHomework.Models;
using DbHomework.Scripts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace DbHomework.Repositories;

public class ToDoItemRepository(IOptions<ConnectionStringOptions> config) : IToDoItemRepository
{
    private readonly string? _connectionString = config.Value.AppConnection;
    private readonly int _commandTimeout = TimeSpan.FromSeconds(5).Seconds;

    public async Task<long> Create(ToDoItemDto dto, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);

        await using var command = connection.CreateCommand();
        command.CommandTimeout = _commandTimeout;

        command.CommandText = Sql.ToDoItemCreate;

        AddCreateParameters(command, dto);

        var toDoItem = await command.ExecuteScalarAsync(ct);
        var toDoItemId = long.Parse(toDoItem.ToString());


        return toDoItemId;
    }

    public async IAsyncEnumerable<ToDoItemDto> GetList(CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);

        await using var command = connection.CreateCommand();
        command.CommandTimeout = _commandTimeout;

        command.CommandText = Sql.GetToDoItems;

        await using var reader = await command.ExecuteReaderAsync(ct);
        while (await reader.ReadAsync(ct))
        {
            yield return await reader.GetToDoItemDto(ct);
        }
    }

    public async Task<ActionResult<ToDoItemDto>?> Get(int todoItemId, CancellationToken ct)
    {
        await using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync(ct);

        await using var command = connection.CreateCommand();
        command.CommandTimeout = _commandTimeout;
        command.Parameters.AddWithValue("Id", todoItemId);

        command.CommandText = Sql.GetToDoItem;
        await using var reader = await command.ExecuteReaderAsync(ct);
        if (await reader.ReadAsync(ct))
        {
            return await reader.GetToDoItemDto(ct);
        }

        return null;
    }

    private static void AddCreateParameters(MySqlCommand command, ToDoItemDto dto)
    {
        command.Parameters.AddWithValue("title", dto.Title);
        command.Parameters.AddWithValue("description", dto.Description);
        command.Parameters.AddWithValue("createdDateTime", dto.CreatedDateTime);
        command.Parameters.AddWithValue("modifiedDateTime", dto.ModifiedDateTime);
    }
}

public static partial class SqlMapper
{
    public static async Task<ToDoItemDto> GetToDoItemDto(this DbDataReader reader, CancellationToken ct)
    {
        return new ToDoItemDto()
        {
            Id = reader.GetInt64("Id"),
            Title = reader.GetString("Title"),
            Description = reader.GetString("Description"),
            CreatedDateTime = reader.GetDateTime("CreatedDateTime"),
            ModifiedDateTime = !await reader.IsDBNullAsync("ModifiedDateTime", ct)
                ? reader.GetDateTime("ModifiedDateTime")
                : null
        };
    }
}
