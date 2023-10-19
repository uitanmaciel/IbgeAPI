using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeAPI.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndexEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Email_Address",
                table: "Users",
                column: "Email_Address",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email_Address",
                table: "Users");
        }
    }
}
