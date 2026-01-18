using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRongParametersAndSolveTheBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasDelevery",
                table: "Restaurants",
                newName: "HasDelivery");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "HasDelivery",
                table: "Restaurants",
                newName: "HasDelevery");
        }
    }
}
