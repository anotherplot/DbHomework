using DbHomework.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbHomework.Controllers;

public class TodoItemService: IDisposable
{
    private readonly ILogger<TodoItemService> _logger;
    private readonly HttpClient _httpClient;

    public TodoItemService(ILogger<TodoItemService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
        public void Dispose()
    {
        _logger.LogInformation("{Type} disposed", nameof(TodoItemService));
    }

    public async Task<ActionResult<TodoItem>> Get(int todoItemId)
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<TodoItem>> GetList()
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<TodoItem>> CreateAndSaveToDb(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}
