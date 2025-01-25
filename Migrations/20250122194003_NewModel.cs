using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class NewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userselection",
                table: "userselection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotel",
                table: "hotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.RenameTable(
                name: "userselection",
                newName: "Userselection");

            migrationBuilder.RenameTable(
                name: "hotel",
                newName: "Hotel");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Events");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Events",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Events",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userselection",
                table: "Userselection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Userselection",
                table: "Userselection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Userselection",
                newName: "userselection");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "hotel");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "events");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "events",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "events",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userselection",
                table: "userselection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotel",
                table: "hotel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "Id");
        }
    }
}
