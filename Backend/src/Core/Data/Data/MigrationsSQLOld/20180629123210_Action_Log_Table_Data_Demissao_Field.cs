using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RiscServicesHRSharepointAddIn.Migrations
{
  public partial class Action_Log_Table_Data_Demissao_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Demissao",
                table: "Usuarios",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Areas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Log_Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action_Dest = table.Column<string>(type: "varchar(255)", nullable: true),
                    Action_Type = table.Column<string>(type: "varchar(255)", nullable: true),
                    Data_Acesso = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ip_Origem = table.Column<string>(type: "varchar(255)", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(255)", nullable: false),
                    matriculaUsuario = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_Actions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Nome",
                table: "Areas",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log_Actions");

            migrationBuilder.DropIndex(
                name: "IX_Areas_Nome",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Data_Demissao",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Areas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
