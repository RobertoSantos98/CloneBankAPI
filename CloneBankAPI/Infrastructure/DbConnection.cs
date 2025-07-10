using CloneBankAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloneBankAPI.Infrastructure
{
    public class DbConnection : DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.CPF)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.PasswordHashed)
                .IsRequired();

            modelBuilder.Entity<Conta>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Conta>()
                .Property(c => c.Saldo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Conta>()
                .Property(c => c.TipoConta)
                .HasConversion<string>();

            modelBuilder.Entity<Conta>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Contas)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Conta_Usuario");

            modelBuilder.Entity<Transferencia>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Transferencia>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transferencia>()
                .HasOne(t=> t.Pagador)
                .WithMany()
                .HasForeignKey(t => t.IdPagador)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transferencia_Pagador");

            modelBuilder.Entity<Transferencia>()
                .HasOne(t => t.Recebedor)
                .WithMany()
                .HasForeignKey(t => t.IdRecebedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transferencia_Recebedor");

            



        }
    }
}
