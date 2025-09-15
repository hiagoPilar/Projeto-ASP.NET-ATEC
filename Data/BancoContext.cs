using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.ViewModels;

namespace Projeto_ASP.NET_Core_ATEC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {
            
        } 

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<ProjetoFuncionario> ProjetoFuncionarios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        //ligação com a ViewModel
        public DbSet<RelatorioProjetosViewModel> RelatorioProjetosViewModel { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);
            

            // Configuração para a ViewModel para ligacao da consulta SQL
            modelBuilder.Entity<RelatorioProjetosViewModel>().HasNoKey().ToView(null);


            // Configurações com Fluent API
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Projetos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjetoFuncionario>()
                .HasKey(pf => new { pf.ProjetoId, pf.FuncionarioId });

            modelBuilder.Entity<ProjetoFuncionario>()
                .HasOne(pf => pf.Projeto)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(pf => pf.ProjetoId);

            modelBuilder.Entity<ProjetoFuncionario>()
                .HasOne(pf => pf.Funcionario)
                .WithMany(f => f.Projetos)
                .HasForeignKey(pf => pf.FuncionarioId);

            
        }

    }
} 
