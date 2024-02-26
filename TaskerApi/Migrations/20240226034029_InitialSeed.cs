using Microsoft.EntityFrameworkCore.Migrations;
using TaskerApi.Models;

#nullable disable

namespace TaskerApi.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[]
                {
                    "Title", "Description", "Deleted", "DueDate"
                },
                values: new object[,] {
                   { "Task1", "This is task 1", 0, DateTime.UtcNow },
                   { "Task2", "This is task 2", 0, DateTime.UtcNow },
                   { "Task3", "This is task 3", 0, DateTime.UtcNow },
                   { "Task4", "This is task 4", 1, DateTime.UtcNow },
                   { "Task5", "This is task 5", 0, DateTime.UtcNow },
           }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
