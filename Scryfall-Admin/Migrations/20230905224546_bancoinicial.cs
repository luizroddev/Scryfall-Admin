using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scryfall_Admin.Migrations
{
    /// <inheritdoc />
    public partial class bancoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageUris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Small = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Normal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Large = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Standard = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modern = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Legacy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pauper = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Duel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Predh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Mana = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CustoDeMana = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Poder = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Resistencia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LegalidadesId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ImageUrisId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Lealdade = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Raridade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FlavorText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartas_ImageUris_ImageUrisId",
                        column: x => x.ImageUrisId,
                        principalTable: "ImageUris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartas_Legalidades_LegalidadesId",
                        column: x => x.LegalidadesId,
                        principalTable: "Legalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_ImageUrisId",
                table: "Cartas",
                column: "ImageUrisId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_LegalidadesId",
                table: "Cartas",
                column: "LegalidadesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartas");

            migrationBuilder.DropTable(
                name: "ImageUris");

            migrationBuilder.DropTable(
                name: "Legalidades");
        }
    }
}
