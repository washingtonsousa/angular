using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class migrationMySQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    imgStr = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaConhecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Categoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaConhecimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log_Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data_Acesso = table.Column<DateTime>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Matricula_Usuario = table.Column<string>(nullable: false),
                    Host_Address = table.Column<string>(nullable: true),
                    Action_Dest = table.Column<string>(nullable: true),
                    Action_Type = table.Column<string>(nullable: true),
                    Action_Details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelAcessos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nivel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelAcessos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
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
                name: "Conhecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    CategoriaConhecimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conhecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conhecimentos_CategoriaConhecimentos_CategoriaConhecimentoId",
                        column: x => x.CategoriaConhecimentoId,
                        principalTable: "CategoriaConhecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email_Secundario_Notificacao = table.Column<string>(nullable: true),
                    Ramal = table.Column<long>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    NivelAcessoId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    CargoId = table.Column<int>(nullable: false),
                    DataAdmissao = table.Column<DateTime>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    EstadoCivil = table.Column<string>(nullable: true),
                    profileImage64string = table.Column<string>(type: "text", nullable: true),
                    Data_Demissao = table.Column<DateTime>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Ext = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: false),
                    Data_Referencia = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Periodo = table.Column<string>(nullable: false),
                    Instituicao = table.Column<string>(nullable: false),
                    Certificadora = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Fixo = table.Column<long>(nullable: false),
                    Celular = table.Column<long>(nullable: false),
                    EmailContato = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpProfissionais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    UltimoSalario = table.Column<float>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Instituicao = table.Column<string>(nullable: false),
                    Curso = table.Column<string>(nullable: false),
                    TipoCurso = table.Column<string>(nullable: false),
                    Situacao = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
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
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Fluencia = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    Conteudo = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Criado_em = table.Column<DateTime>(nullable: false),
                    Atualizado_em = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    ConhecimentoId = table.Column<int>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Nome",
                table: "Areas",
                column: "Nome",
                unique: true);

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
                name: "IX_Conhecimentos_CategoriaConhecimentoId",
                table: "Conhecimentos",
                column: "CategoriaConhecimentoId");

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
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

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
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Log_Actions");

            migrationBuilder.DropTable(
                name: "Resumos");

            migrationBuilder.DropTable(
                name: "UsuarioConhecimento");

            migrationBuilder.DropTable(
                name: "Conhecimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CategoriaConhecimentos");

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
