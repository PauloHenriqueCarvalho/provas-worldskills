using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProvaM3_API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendimento> Atendimentos { get; set; }

    public virtual DbSet<AtendimentoProduto> AtendimentoProdutos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DoseProduto> DoseProdutos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Feriado> Feriados { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Profissional> Profissionals { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Sessao3Mobile;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atendimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Atendime__3214EC072E03EB71");

            entity.ToTable("Atendimento");

            entity.Property(e => e.DataAgendada).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Atendimento_Cliente");

            entity.HasOne(d => d.Profissional).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.ProfissionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Atendimento_Profissional");

            entity.HasOne(d => d.Servico).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.ServicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Atendimento_Servico");
        });

        modelBuilder.Entity<AtendimentoProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Atendime__3214EC073EC7A41E");

            entity.ToTable("AtendimentoProduto");

            entity.HasOne(d => d.Atendimento).WithMany(p => p.AtendimentoProdutos)
                .HasForeignKey(d => d.AtendimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AtendimentoProduto_Atendimento");

            entity.HasOne(d => d.Produto).WithMany(p => p.AtendimentoProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AtendimentoProduto_Produto");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07FD573FA3");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Cpf, "UQ__Cliente__C1F897319F24C8CC").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CPF");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Pessoa");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.InverseResponsavel)
                .HasForeignKey(d => d.ResponsavelId)
                .HasConstraintName("FK_Cliente_Responsavel");
        });

        modelBuilder.Entity<DoseProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoseProd__3214EC076039842C");

            entity.ToTable("DoseProduto");

            entity.Property(e => e.DataHoraDose).HasColumnType("datetime");

            entity.HasOne(d => d.Cliente).WithMany(p => p.DoseProdutos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dose_Cliente");

            entity.HasOne(d => d.Produto).WithMany(p => p.DoseProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dose_Produto");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Endereco__3214EC070DCB58A7");

            entity.ToTable("Endereco");

            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TipoEndereco)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Endereco_Pessoa");
        });

        modelBuilder.Entity<Feriado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feriado__3214EC07526F71A2");

            entity.ToTable("Feriado");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forneced__3214EC070F6933A1");

            entity.ToTable("Fornecedor");

            entity.HasIndex(e => e.Cnpj, "UQ__Forneced__AA57D6B43CC822F0").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cnpj)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Fornecedor)
                .HasForeignKey<Fornecedor>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fornecedor_Pessoa");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pessoa__3214EC070D9E101A");

            entity.ToTable("Pessoa");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC0737F88E7B");

            entity.ToTable("Produto");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produto_Fornecedor");
        });

        modelBuilder.Entity<Profissional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profissi__3214EC079192B5A6");

            entity.ToTable("Profissional");

            entity.HasIndex(e => e.Cpf, "UQ__Profissi__C1F897317F1C80F0").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConselhoRegistro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.TipoProfissional)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Profissional)
                .HasForeignKey<Profissional>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Profissional_Pessoa");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servico__3214EC07DC0A0031");

            entity.ToTable("Servico");

            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecoBase).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC077F7BC4B4");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Login, "UQ__Usuario__5E55825B7EE43DD9").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Perfil)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SenhaHash)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Pessoa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
