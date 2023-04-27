using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace puzzle.backend.coding.callenge.NETCore.Migrations
{
    /// <inheritdoc />
    public partial class booking_table_was_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ClientId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Event_EventId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Furniture_FurnitureId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Status_StatusId",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Furniture",
                table: "Furniture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "Furniture",
                newName: "Furnitures");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Client_StatusId",
                table: "Clients",
                newName: "IX_Clients_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_FurnitureId",
                table: "Bookings",
                newName: "IX_Bookings_FurnitureId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_EventId",
                table: "Bookings",
                newName: "IX_Bookings_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ClientId",
                table: "Bookings",
                newName: "IX_Bookings_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Furnitures",
                table: "Furnitures",
                column: "FurnitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StatusId",
                table: "Bookings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Clients_ClientId",
                table: "Bookings",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings",
                column: "FurnitureId",
                principalTable: "Furnitures",
                principalColumn: "FurnitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Statuses_StatusId",
                table: "Bookings",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Clients_ClientId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Furnitures_FurnitureId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Statuses_StatusId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Statuses_StatusId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Furnitures",
                table: "Furnitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StatusId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.RenameTable(
                name: "Furnitures",
                newName: "Furniture");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_StatusId",
                table: "Client",
                newName: "IX_Client_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_FurnitureId",
                table: "Booking",
                newName: "IX_Booking_FurnitureId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EventId",
                table: "Booking",
                newName: "IX_Booking_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ClientId",
                table: "Booking",
                newName: "IX_Booking_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Furniture",
                table: "Furniture",
                column: "FurnitureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ClientId",
                table: "Booking",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Event_EventId",
                table: "Booking",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Furniture_FurnitureId",
                table: "Booking",
                column: "FurnitureId",
                principalTable: "Furniture",
                principalColumn: "FurnitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Status_StatusId",
                table: "Client",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
