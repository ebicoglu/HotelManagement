using Microsoft.EntityFrameworkCore.Migrations;

namespace Hilton.HotelManagement.Migrations
{
    public partial class Updated_19052311081050_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "AppReservation",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppReservation");
        }
    }
}
