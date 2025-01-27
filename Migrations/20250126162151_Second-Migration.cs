using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Userselection");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Userselection",
                newName: "NumberOfPeople");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Userselection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Userselection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Userselection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotelName",
                table: "Userselection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "Userselection",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Userselection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Userselection",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "UserSelectionViewModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    IsVIP = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelectionViewModels", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSelectionViewModels");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "HotelName",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Userselection");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Userselection");

            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "Userselection",
                newName: "HotelId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Userselection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
