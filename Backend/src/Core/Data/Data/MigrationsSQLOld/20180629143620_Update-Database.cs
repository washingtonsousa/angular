using Microsoft.EntityFrameworkCore.Migrations;

namespace RiscServicesHRSharepointAddIn.Migrations
{
  public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_Secundario_Notificacao",
                table: "Usuarios",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_Secundario_Notificacao",
                table: "Usuarios");
        }
    }
}
