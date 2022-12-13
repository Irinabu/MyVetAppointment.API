using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVetAppointment.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillStatus",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillStatus",
                table: "Bills");
        }
    }
}
