using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model;

public partial class Context : DbContext
{
    public virtual DbSet<Ip> Ips { get; set; }
    public virtual DbSet<Entrega> Entregas { get; set; }
    public virtual DbSet<Entregador> Entregadores { get; set; }
    public virtual DbSet<EntregaEntregador> EntregasEntregadores { get; set; }
    public virtual DbSet<ResponsavelBosch> ResponsaveisBosch { get; set; }
    public virtual DbSet<Transponder> Transponders { get; set; }
    public virtual DbSet<Transportadora> Transportadoras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string computador = Environment.MachineName;
        //computador += "\\SQLEXPRESS";
        string database = "PMCD";
        optionsBuilder.UseSqlServer("Server=" + computador + ";Database=" + database + ";Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transponder>(entity =>
        {
            entity.ToTable("Transponder");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Codigo);
        });

        modelBuilder.Entity<Ip>(entity =>
        {
            entity.ToTable("Ip");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EnderecoIp);
        });

        modelBuilder.Entity<Entregador>(entity =>
        {
            entity.ToTable("Entregador");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome);
            entity.Property(e => e.Documento);
            entity.Property(e => e.DataNascimento);
        });

        modelBuilder.Entity<ResponsavelBosch>(entity =>
        {
            entity.ToTable("ResponsavelBosch");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome);
            entity.Property(e => e.Documento);
            entity.Property(e => e.Edv);
        });

        modelBuilder.Entity<Transportadora>(entity =>
        {
            entity.ToTable("Transportadora");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome);
            entity.Property(e => e.Cnpj);
            entity.Property(e => e.Senha);
            entity.Property(e => e.PrimeiroAcesso);
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.ToTable("Entrega");
            
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PlacaCarro);
            entity.Property(e => e.CodigoInterno);
            entity.Property(e => e.PesoEntrada);
            entity.Property(e => e.PesoSaida);
            entity.Property(e => e.DataEntrega);
            entity.Property(e => e.Liberado);
            entity.Property(e => e.NotaFiscal);

            entity.HasOne(d => d.Transponder)
                .WithMany(p => p.EntregaList)
                .HasForeignKey(d => d.IdTransponder);

            entity.HasOne(d => d.Transportadora)
                .WithMany(p => p.EntregaList)
                .HasForeignKey(d => d.IdTransportadora);

            entity.HasOne(d => d.ResponsavelBosch)
                .WithMany(p => p.EntregaList)
                .HasForeignKey(d => d.IdResponsavelBosch);
        });

        modelBuilder.Entity<EntregaEntregador>(entity =>
        {
            entity.ToTable("EntregaEntregador");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Motorista);

            entity.HasOne(d => d.Entrega)
                .WithMany(p => p.EntregaEntregadorList)
                .HasForeignKey(d => d.IdEntrega);

            entity.HasOne(d => d.Entregador)
                .WithMany(p => p.EntregaEntregadorList)
                .HasForeignKey(d => d.IdEntregador);
        });
    }
}
