using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiscServicesHRSharepointAddIn.Migrations
{
    public partial class createCategoriaConhecimentoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaConhecimentoId",
                table: "Conhecimentos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instituicao",
                table: "CertCursos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaConhecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaConhecimentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conhecimentos_CategoriaConhecimentoId",
                table: "Conhecimentos",
                column: "CategoriaConhecimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conhecimentos_CategoriaConhecimentos_CategoriaConhecimentoId",
                table: "Conhecimentos",
                column: "CategoriaConhecimentoId",
                principalTable: "CategoriaConhecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conhecimentos_CategoriaConhecimentos_CategoriaConhecimentoId",
                table: "Conhecimentos");

            migrationBuilder.DropTable(
                name: "CategoriaConhecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Conhecimentos_CategoriaConhecimentoId",
                table: "Conhecimentos");

            migrationBuilder.DropColumn(
                name: "CategoriaConhecimentoId",
                table: "Conhecimentos");

            migrationBuilder.AlterColumn<string>(
                name: "Periodo",
                table: "CertCursos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Instituicao",
                table: "CertCursos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
