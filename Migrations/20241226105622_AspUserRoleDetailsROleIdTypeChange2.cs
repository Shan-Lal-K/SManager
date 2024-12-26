using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STUDMANAG.Migrations
{
    public partial class AspUserRoleDetailsROleIdTypeChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspRoleId",
                table: "AspUserRoleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspRoleId",
                table: "AspUserRoleDetails");
        }
    }
}
