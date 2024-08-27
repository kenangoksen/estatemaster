using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateMaster.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "loginDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loginDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Users");
        }
    }
}
