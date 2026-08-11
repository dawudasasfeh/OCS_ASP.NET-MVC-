using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Task1.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmployeeModelId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModelId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeModelId",
                table: "Tasks",
                column: "EmployeeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeModelId",
                table: "Tasks",
                column: "EmployeeModelId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
