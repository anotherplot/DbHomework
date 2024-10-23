namespace DbHomework.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }

    public override string ToString() => $"TodoItem.Id = {Id.ToString()}";
}
