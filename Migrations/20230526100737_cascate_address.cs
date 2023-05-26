using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlDemo.Migrations
{
    /// <inheritdoc />
    public partial class cascate_address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddress_Employee_EmployeeId",
                table: "EmployeeAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddress_Employee_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddress_Employee_EmployeeId",
                table: "EmployeeAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddress_Employee_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }
    }
}
