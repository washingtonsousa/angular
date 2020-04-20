using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RiscServicesHRSharepointAddIn.Migrations
{
  public partial class create_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conhecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conhecimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelAcessos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nivel = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcessos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(255)", nullable: false),
                    Matricula = table.Column<long>(type: "bigint", nullable: false),
                    NivelAcessoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_NivelAcessos_NivelAcessoId",
                        column: x => x.NivelAcessoId,
                        principalTable: "NivelAcessos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Data_Referencia = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Ext = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(255)", nullable: false),
                    URL = table.Column<string>(type: "varchar(450)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CertCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Certificadora = table.Column<string>(type: "varchar(255)", nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Instituicao = table.Column<string>(type: "varchar(255)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Periodo = table.Column<string>(type: "varchar(255)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertCursos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Celular = table.Column<long>(type: "bigint", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: true),
                    EmailContato = table.Column<string>(type: "varchar(255)", nullable: true),
                    Fixo = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(255)", nullable: false),
                    CEP = table.Column<long>(type: "bigint", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(255)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(255)", nullable: true),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "varchar(255)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(255)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpProfissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Empresa = table.Column<string>(type: "varchar(255)", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimoSalario = table.Column<float>(type: "real", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpProfissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpProfissionais_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormAcademicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Curso = table.Column<string>(type: "varchar(255)", nullable: false),
                    Instituicao = table.Column<string>(type: "varchar(255)", nullable: false),
                    Situacao = table.Column<string>(type: "varchar(255)", nullable: true),
                    TipoCurso = table.Column<string>(type: "varchar(255)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAcademicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAcademicas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gestores_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gestores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fluencia = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idiomas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atualizado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConhecimentoId = table.Column<int>(type: "int", nullable: false),
                    Criado_em = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioConhecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioConhecimento_Conhecimentos_ConhecimentoId",
                        column: x => x.ConhecimentoId,
                        principalTable: "Conhecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioConhecimento_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_URL",
                table: "Arquivos",
                column: "URL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_UsuarioId",
                table: "Arquivos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CertCursos_UsuarioId",
                table: "CertCursos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_AreaId",
                table: "Departamentos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpProfissionais_UsuarioId",
                table: "ExpProfissionais",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAcademicas_UsuarioId",
                table: "FormAcademicas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_DepartamentoId",
                table: "Gestores",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_UsuarioId",
                table: "Gestores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Idiomas_UsuarioId",
                table: "Idiomas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumos_UsuarioId",
                table: "Resumos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioConhecimento_ConhecimentoId",
                table: "UsuarioConhecimento",
                column: "ConhecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioConhecimento_UsuarioId",
                table: "UsuarioConhecimento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Matricula",
                table: "Usuarios",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NivelAcessoId",
                table: "Usuarios",
                column: "NivelAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_StatusId",
                table: "Usuarios",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "CertCursos");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "ExpProfissionais");

            migrationBuilder.DropTable(
                name: "FormAcademicas");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Resumos");

            migrationBuilder.DropTable(
                name: "UsuarioConhecimento");

            migrationBuilder.DropTable(
                name: "Conhecimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "NivelAcessos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Areas"); 
        }
    }
}
