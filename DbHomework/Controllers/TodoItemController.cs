using DbHomework.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbHomework.Controllers;

public class TodoItemController(TodoItemService todoItemService): ControllerBase
{
    [HttpGet("{todoItem}")]
    public async Task<ActionResult<TodoItem>> Get(int todoItemId)
    {
        var todoItem = await todoItemService.Get(todoItemId);
        return todoItem;
    }

    [HttpGet]
    public async Task<ActionResult<TodoItem>> GetList()
    {
        var todoItem = await todoItemService.GetList();
        return todoItem;
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> Create([FromBody]TodoItem todoItem)
    {
        return await todoItemService.CreateAndSaveToDb(todoItem);
    }
}
