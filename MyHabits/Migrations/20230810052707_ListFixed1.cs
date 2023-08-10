using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHabits.Migrations
{
    /// <inheritdoc />
    public partial class ListFixed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DauOfHabit_Habit_HabitId",
                table: "DauOfHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DauOfHabit",
                table: "DauOfHabit");

            migrationBuilder.RenameTable(
                name: "DauOfHabit",
                newName: "DayOfHabit");

            migrationBuilder.RenameIndex(
                name: "IX_DauOfHabit_HabitId",
                table: "DayOfHabit",
                newName: "IX_DayOfHabit_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayOfHabit",
                table: "DayOfHabit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOfHabit_Habit_HabitId",
                table: "DayOfHabit",
                column: "HabitId",
                principalTable: "Habit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOfHabit_Habit_HabitId",
                table: "DayOfHabit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayOfHabit",
                table: "DayOfHabit");

            migrationBuilder.RenameTable(
                name: "DayOfHabit",
                newName: "DauOfHabit");

            migrationBuilder.RenameIndex(
                name: "IX_DayOfHabit_HabitId",
                table: "DauOfHabit",
                newName: "IX_DauOfHabit_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DauOfHabit",
                table: "DauOfHabit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DauOfHabit_Habit_HabitId",
                table: "DauOfHabit",
                column: "HabitId",
                principalTable: "Habit",
                principalColumn: "Id");
        }
    }
}
