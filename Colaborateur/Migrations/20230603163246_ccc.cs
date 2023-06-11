using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colaborateur.Migrations
{
    /// <inheritdoc />
    public partial class ccc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Collaborateurs",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Collaborateurs");
        }
    }
}
