using DbHomework.Models;
using DbHomework.Repositories;
using DbHomework.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DbHomework.Controllers;

[ApiController]
[Controller]
[Route("api/")]
public class TodoItemController(IToDoItemRepository toDoItemRepository) : ControllerBase
{
    [HttpPost("CreateToDoItem")]
    public async Task<ActionResult<long>> Create([FromBody] CreateToDoItemRequest createToDoItemRequest,
        CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var dto = new ToDoItemDto
        {
            Title = createToDoItemRequest.Title,
            Description = createToDoItemRequest.Description,
            CreatedDateTime = DateTime.Now,
            ModifiedDateTime = null
        };

        return await toDoItemRepository.Create(dto, ct);
    }

    [HttpGet("GetToDoItem")]
    [Produces("application/json")]
    public async Task<ActionResult<ToDoItemDto>> Get(int todoItemId, CancellationToken ct)
    {
        var result = await toDoItemRepository.Get(todoItemId, ct);
        if (result == null) return NotFound();
        return result;
    }

    [HttpGet("GetToDoItemsList")]
    [Produces("application/json")]
    public ActionResult GetList(CancellationToken ct)
    {
        var result = toDoItemRepository.GetList(ct);
        return Ok(result);
    }
}
