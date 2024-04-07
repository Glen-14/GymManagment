using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagment.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembersID",
                table: "MemberSubscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberSubscriptions_MembersID",
                table: "MemberSubscriptions",
                column: "MembersID");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSubscriptions_Members_MembersID",
                table: "MemberSubscriptions",
                column: "MembersID",
                principalTable: "Members",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberSubscriptions_Members_MembersID",
                table: "MemberSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_MemberSubscriptions_MembersID",
                table: "MemberSubscriptions");

            migrationBuilder.DropColumn(
                name: "MembersID",
                table: "MemberSubscriptions");
        }
    }
}
