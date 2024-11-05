using DbHomework.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbHomework.Repositories;

public interface IToDoItemRepository
{
    Task<long> Create(ToDoItemDto dto, CancellationToken ct);
    IAsyncEnumerable<ToDoItemDto> GetList(CancellationToken ct);
    Task<ActionResult<ToDoItemDto>?> Get(int todoItemId, CancellationToken ct);
}
