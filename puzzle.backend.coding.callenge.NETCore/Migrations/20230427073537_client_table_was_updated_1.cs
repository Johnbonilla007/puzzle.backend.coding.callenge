using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace puzzle.backend.coding.callenge.NETCore.Migrations
{
    /// <inheritdoc />
    public partial class client_table_was_updated_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FurnitureId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Furnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_BookingId",
                table: "Furnitures",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_Bookings_BookingId",
                table: "Furnitures",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_Bookings_BookingId",
                table: "Furnitures");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_BookingId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FurnitureId",
                table: "Bookings",
                column: "FurnitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings",
                column: "FurnitureId",
                principalTable: "Furnitures",
                principalColumn: "FurnitureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
