using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TarefasAPI.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tarefa> Tarefas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TarefasDB;User Id=sa;Password=1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3213E83F1DF4C6F0");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("#808080");
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarefa__3213E83F32E74242");

            entity.ToTable("Tarefa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.DataVencimento).HasColumnName("dataVencimento");
            entity.Property(e => e.Descricao)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioDestinatario).HasColumnName("usuarioDestinatario");
            entity.Property(e => e.UsuarioRemetente).HasColumnName("usuarioRemetente");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Tarefas)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Tarefa__status__3F466844");

            entity.HasOne(d => d.UsuarioDestinatarioNavigation).WithMany(p => p.TarefaUsuarioDestinatarioNavigations)
                .HasForeignKey(d => d.UsuarioDestinatario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarefa__usuarioD__403A8C7D");

            entity.HasOne(d => d.UsuarioRemetenteNavigation).WithMany(p => p.TarefaUsuarioRemetenteNavigations)
                .HasForeignKey(d => d.UsuarioRemetente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarefa__usuarioR__412EB0B6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F97C396AC");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Login, "UQ__Usuario__7838F2725FC522AF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dataCadastro");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
