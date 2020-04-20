using Microsoft.EntityFrameworkCore.Migrations;

namespace RiscServicesHRSharepointAddIn.Migrations
{
  public partial class Action_Log_Corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip_Origem",
                table: "Log_Actions");

            migrationBuilder.DropColumn(
                name: "matriculaUsuario",
                table: "Log_Actions");

            migrationBuilder.AddColumn<string>(
                name: "Host_Address",
                table: "Log_Actions",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricula_Usuario",
                table: "Log_Actions",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Host_Address",
                table: "Log_Actions");

            migrationBuilder.DropColumn(
                name: "Matricula_Usuario",
                table: "Log_Actions");

            migrationBuilder.AddColumn<string>(
                name: "Ip_Origem",
                table: "Log_Actions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "matriculaUsuario",
                table: "Log_Actions",
                nullable: false,
                defaultValue: "");
        }
    }
}
