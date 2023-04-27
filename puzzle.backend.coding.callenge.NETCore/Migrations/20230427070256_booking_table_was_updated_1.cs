using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace puzzle.backend.coding.callenge.NETCore.Migrations
{
    /// <inheritdoc />
    public partial class booking_table_was_updated_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FurnitureId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings",
                column: "FurnitureId",
                principalTable: "Furnitures",
                principalColumn: "FurnitureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Furnitures");

            migrationBuilder.AlterColumn<int>(
                name: "FurnitureId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings",
                column: "FurnitureId",
                principalTable: "Furnitures",
                principalColumn: "FurnitureId");
        }
    }
}
