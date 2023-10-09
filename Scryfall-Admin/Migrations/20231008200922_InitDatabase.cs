using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scryfall_Admin.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Lealdade = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    FlavorText = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Raridade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LegalidadesId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ImagemUrisId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageUris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Small = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Normal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Large = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CartaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUris_Cartas_CartaId",
                        column: x => x.CartaId,
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Predh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CartaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legalidades_Cartas_CartaId",
                        column: x => x.CartaId,
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageUris_CartaId",
                table: "ImageUris",
                column: "CartaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Legalidades_CartaId",
                table: "Legalidades",
                column: "CartaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUris");

            migrationBuilder.DropTable(
                name: "Legalidades");

            migrationBuilder.DropTable(
                name: "Cartas");
        }
    }
}
