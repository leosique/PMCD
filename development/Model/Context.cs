using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model;

public partial class Context : DbContext
{

    public virtual DbSet<Entrega> Entregas { get; set; }
    public virtual DbSet<Entregador> Entregadores { get; set; }
    public virtual DbSet<EntregaEntregador> EntregasEntregadores { get; set; }
    public virtual DbSet<ResponsavelBosch> ResponsaveisBosch { get; set; }
    public virtual DbSet<Transponder> Transponders { get; set; }
    public virtual DbSet<Transportadora> Transportadoras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string computador = Environment.MachineName;
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
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.ToTable("Entrega");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PlacaCarro);
            entity.Property(e => e.CodigoInterno);
            entity.Property(e => e.PesoEntrada);
            entity.Property(e => e.PesoSaida);

            entity.HasOne(d => d.Transponder);

            entity.HasOne(d => d.Transportadora)
                .WithMany(p => p.EntregasFeitas)
                .HasForeignKey(d => d.IdTransportadora);

            entity.HasOne(d => d.ResponsavelBosch)
                .WithMany(p => p.EntregasFeitas)
                .HasForeignKey(d => d.IdResponsavelBosch);
        });

        modelBuilder.Entity<EntregaEntregador>(entity =>
        {
            entity.ToTable("EntregaEntregador");
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Entrega)
                .WithMany(p => p.ListaEntregasEntregadores)
                .HasForeignKey(d => d.IdEntrega);

            entity.HasOne(d => d.Entregador)
                .WithMany(p => p.ListaEntregasEntregadores)
                .HasForeignKey(d => d.IdEntregador);
        });
    }
}
