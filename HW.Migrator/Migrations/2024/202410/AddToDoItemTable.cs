using FluentMigrator;

namespace HW.Migrator.Migrations._2024._202410;

[Migration(20241023_2040)]
public class AddToDoItemTable : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TABLE IF NOT EXISTS `toDoItems` (
              `Id` int(11) NOT NULL AUTO_INCREMENT,
              `Title` longtext NOT NULL,
              `Description` longtext DEFAULT NULL,
              `CreatedDateTime` datetime(6) NOT NULL,
              `ModifiedDateTime` datetime(6) DEFAULT NULL,
              PRIMARY KEY (`Id`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4
        ");
    }

    public override void Down()
    {
        //empty, not using
    }
}
