using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHabits.Migrations
{
    /// <inheritdoc />
    public partial class List2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Habit",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "DauOfHabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _if_action = table.Column<bool>(type: "bit", nullable: false),
                    HabitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DauOfHabit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DauOfHabit_Habit_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DauOfHabit_HabitId",
                table: "DauOfHabit",
                column: "HabitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DauOfHabit");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Habit",
                newName: "_id");
        }
    }
}
