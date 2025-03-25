using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateMaster.Server.Migrations
{
    /// <inheritdoc />
    public partial class EstateMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userType",
                table: "Users");
        }
    }
}
