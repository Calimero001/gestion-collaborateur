using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colaborateur.Migrations
{
    /// <inheritdoc />
    public partial class change5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Maricule",
                table: "Collaborateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maricule",
                table: "Collaborateurs");
        }
    }
}
