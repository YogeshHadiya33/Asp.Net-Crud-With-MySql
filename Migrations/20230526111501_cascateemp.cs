using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlDemo.Migrations
{
    /// <inheritdoc />
    public partial class cascateemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");
        }
    }
}
