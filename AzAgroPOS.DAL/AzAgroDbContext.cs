using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.DAL
{
    public class AzAgroDbContext : DbContext
    {
        // Hər cədvəl üçün bir DbSet yaradırıq. EF bu DbSet-lərə əsasən cədvəlləri idarə edəcək.
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Tema> Temalar { get; set; }
        public DbSet<Istifadeci> Istifadeciler { get; set; }
        public DbSet<RolIcazesi> RolIcazeleri { get; set; }
        public DbSet<AuditLog> AuditLoglar { get; set; }

        // Bu metod, EF-ə hansı verilənlər bazasına və necə qoşulacağını deyir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verilənlər bazasının proqramın icra olunduğu qovluqda "azagropos.db" adı ilə yaranmasını təmin edirik.
            optionsBuilder.UseSqlite("Data Source=azagropos.db");
        }
    }
}