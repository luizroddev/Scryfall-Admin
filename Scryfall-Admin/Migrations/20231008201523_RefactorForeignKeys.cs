using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scryfall_Admin.Migrations
{
    /// <inheritdoc />
    public partial class RefactorForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUris_Cartas_CartaId",
                table: "ImageUris");

            migrationBuilder.DropForeignKey(
                name: "FK_Legalidades_Cartas_CartaId",
                table: "Legalidades");

            migrationBuilder.DropIndex(
                name: "IX_Legalidades_CartaId",
                table: "Legalidades");

            migrationBuilder.DropIndex(
                name: "IX_ImageUris_CartaId",
                table: "ImageUris");

            migrationBuilder.DropColumn(
                name: "CartaId",
                table: "Legalidades");

            migrationBuilder.DropColumn(
                name: "CartaId",
                table: "ImageUris");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_ImagemUrisId",
                table: "Cartas",
                column: "ImagemUrisId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartas_LegalidadesId",
                table: "Cartas",
                column: "LegalidadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_ImageUris_ImagemUrisId",
                table: "Cartas",
                column: "ImagemUrisId",
                principalTable: "ImageUris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartas_Legalidades_LegalidadesId",
                table: "Cartas",
                column: "LegalidadesId",
                principalTable: "Legalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartas_ImageUris_ImagemUrisId",
                table: "Cartas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cartas_Legalidades_LegalidadesId",
                table: "Cartas");

            migrationBuilder.DropIndex(
                name: "IX_Cartas_ImagemUrisId",
                table: "Cartas");

            migrationBuilder.DropIndex(
                name: "IX_Cartas_LegalidadesId",
                table: "Cartas");

            migrationBuilder.AddColumn<int>(
                name: "CartaId",
                table: "Legalidades",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartaId",
                table: "ImageUris",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Legalidades_CartaId",
                table: "Legalidades",
                column: "CartaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageUris_CartaId",
                table: "ImageUris",
                column: "CartaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUris_Cartas_CartaId",
                table: "ImageUris",
                column: "CartaId",
                principalTable: "Cartas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Legalidades_Cartas_CartaId",
                table: "Legalidades",
                column: "CartaId",
                principalTable: "Cartas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
