namespace DbHomework.Scripts;

public static partial class Sql
{
    public static string ToDoItemCreate =>
        @"insert into 
    toDoItems(Title, Description, CreatedDateTime, ModifiedDateTime) 
    values (@title, @description, @createdDateTime, @modifiedDateTime);
    select LAST_INSERT_ID()";

    public static string GetToDoItems =>
        @"select * from toDoItems";

    public static string GetToDoItem =>
        @"select * from toDoItems where Id = @Id";


}
