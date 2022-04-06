using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudOperations.Migrations
{
    public partial class dept_std_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentDeptId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentDeptId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptId",
                table: "Students",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DeptId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentDeptId",
                table: "Students",
                column: "DepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentDeptId",
                table: "Students",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");
        }
    }
}
