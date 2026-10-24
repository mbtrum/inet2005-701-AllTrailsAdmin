using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllTrailsAdmin.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoryInTrail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Trail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Trail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
