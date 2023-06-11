using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colaborateur.Migrations
{
    /// <inheritdoc />
    public partial class Initail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N_Tel = table.Column<int>(type: "int", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEntree_SQLI = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    N_Collaborateur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectifsGlobaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteGlobale = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDubut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectifsGlobaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectifsGlobaux_Collaborateurs_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetsCollaborateurs",
                columns: table => new
                {
                    ProjetId = table.Column<int>(type: "int", nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetsCollaborateurs", x => new { x.ProjetId, x.CollaborateurId });
                    table.ForeignKey(
                        name: "FK_ProjetsCollaborateurs_Collaborateurs_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetsCollaborateurs_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectifs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<double>(type: "float", nullable: false),
                    Poit_NoteGlobale = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjectifGlobaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectifs_ObjectifsGlobaux_ObjectifGlobaleId",
                        column: x => x.ObjectifGlobaleId,
                        principalTable: "ObjectifsGlobaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objectifs_ObjectifGlobaleId",
                table: "Objectifs",
                column: "ObjectifGlobaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectifsGlobaux_CollaborateurId",
                table: "ObjectifsGlobaux",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetsCollaborateurs_CollaborateurId",
                table: "ProjetsCollaborateurs",
                column: "CollaborateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objectifs");

            migrationBuilder.DropTable(
                name: "ProjetsCollaborateurs");

            migrationBuilder.DropTable(
                name: "ObjectifsGlobaux");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Collaborateurs");
        }
    }
}
