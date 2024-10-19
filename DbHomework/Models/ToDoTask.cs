namespace DbHomework.Models;

public class ToDoTask
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }

    public override string ToString() => $"ToDoTask.Id = {Id.ToString()}";
}
