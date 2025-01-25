using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class newdet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "events");

            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "events");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");
        }
    }
}
