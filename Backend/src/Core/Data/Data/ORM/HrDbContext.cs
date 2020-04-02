using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;
using Core.Data.Models;
using System;

namespace Core.Data.ORM
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe usada para instanciar o contexto do Entity Framework e realizar a consulta
  /// das entidades no banco de dados
  /// 
  /// A prática recomendada é somente chamar esta classe ao instaciar os repósitórios
  /// 
  /// Respeite o Repository Pattern!
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>


  public class HrDbContext : DbContext
    {

        public HrDbContext()
        {
      
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<NivelAcesso> NivelAcessos { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Resumo> Resumos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<FormAcademica> FormAcademicas { get; set; }
        public DbSet<CertCurso> CertCursos { get; set; }
        public DbSet<ExpProfissional> ExpProfissionais { get; set; }
        public DbSet<Conhecimento> Conhecimentos { get; set; }
        public DbSet<UsuarioConhecimento> UsuarioConhecimentos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Log_Action> Log_Actions { get; set; }
        public DbSet<CategoriaConhecimento> CategoriaConhecimentos { get; set; }

    ////////////////// Chamados Módulo //////////////////////////////

    // public DbSet<Chamado> Chamados { get; set; }
    // public DbSet<ChamadoCategoria> ChamadoCategorias { get; set; }
    // public DbSet<ChamadoMensagem> ChamadoMensagens { get; set; }
    // public DbSet<ChamadoAnexo> ChamadoAnexos { get; set; }

    /// <summary>
    /// Método para configurar o EF no acesso à banco de dados
    /// </summary>
    /// <param name="optionsBuilder">Injeção de depedência do EF Core, Favor consultar documentação
    /// oficial para maiores informações</param>
    ///


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MiriaSQL"].ConnectionString,
            options => options.EnableRetryOnFailure()); // Chama connection String  e habilita nova tentativa quando ocorra falha ao salvar alterações
            base.OnConfiguring(optionsBuilder); // Executa método da classe Pai

    }

   
        /// <summary>
        ///   Método para manipular as entidades e a base de dados durante a construção do Model
        ///   Cosulte da documentação do EF Core para maiores informações
        /// </summary>
        /// <param name="modelBuilder">Injeção de depedência do EF Core, Favor consultar documentação
        /// oficial para maiores informações</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

      modelBuilder.Entity<Usuario>().Property(e => e.profileImage64String)
            .HasColumnType("text");
    

      modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<ExpProfissional>().ToTable("ExpProfissionais");
            modelBuilder.Entity<UsuarioConhecimento>().ToTable("UsuarioConhecimento");
     

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

      modelBuilder.Entity<Usuario>().HasMany(s => s.UsuarioConhecimentos).WithOne(s => s.Usuario);
      modelBuilder.Entity<Conhecimento>().HasMany(s => s.UsuarioConhecimentos).WithOne(s => s.Conhecimento);
      modelBuilder.Entity<CategoriaConhecimento>().HasMany(s => s.Conhecimentos).WithOne(s => s.CategoriaConhecimento);
      modelBuilder.Entity<Usuario>().HasOne(s => s.Status).WithMany(s => s.Usuarios);

      modelBuilder.Entity<Arquivo>().HasIndex(u => u.URL)
            .IsUnique();

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Matricula)
            .IsUnique();

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email)
           .IsUnique();

            modelBuilder.Entity<Area>().HasIndex(u => u.Nome).IsUnique();

            modelBuilder.Entity<CertCurso>()
            .Property(e => e.Descricao)
            .HasColumnType("text");

            modelBuilder.Entity<Log_Action>().Property(l => l.Action_Details).HasColumnType("text");

            modelBuilder.Entity<ExpProfissional>()
            .Property(e => e.Descricao)
            .HasColumnType("text");

             modelBuilder.Entity<Area>()
            .Property(e => e.imgStr)
            .HasColumnType("text");

      modelBuilder.Entity<Arquivo>()
            .Property(e => e.Descricao)
            .HasColumnType("text");


            modelBuilder.Entity<Usuario>().HasOne(u => u.Status);
            base.OnModelCreating(modelBuilder);

        }
    }
}
