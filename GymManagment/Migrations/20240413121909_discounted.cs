using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagment.Migrations
{
    /// <inheritdoc />
    public partial class discounted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Dsicounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Isdeleted",
                table: "DiscountedMemberSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Dsicounts");

            migrationBuilder.DropColumn(
                name: "Isdeleted",
                table: "DiscountedMemberSubscriptions");
        }
    }
}
