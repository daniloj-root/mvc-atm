using caixa_eletronico.Domain.Models;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace caixa_eletronico.Infrastructure.Database
{
    public partial class ATMDbContext : DbContext
    {
        public ATMDbContext()
        {
        }

        public ATMDbContext(DbContextOptions<ATMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<WadOfBills> WadOfBills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ATM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.MonetaryValue)
                    .HasName("PK__Bill__506E777D449EEFEF");

                entity.Property(e => e.MonetaryValue).ValueGeneratedNever();
            });

            modelBuilder.Entity<WadOfBills>(entity =>
            {
                entity.HasKey(e => e.BillValue)
                    .HasName("PK__WadOfBil__D1C905ED7D9BF674");

                entity.Property(e => e.BillValue).ValueGeneratedNever();

                entity.HasOne(d => d.BillValueNavigation)
                    .WithOne(p => p.WadOfBills)
                    .HasForeignKey<WadOfBills>(d => d.BillValue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WadOfBill__BillV__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
