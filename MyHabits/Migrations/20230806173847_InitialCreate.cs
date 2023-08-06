using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHabits.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habit",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _date_of_start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habit", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habit");
        }
    }
}
