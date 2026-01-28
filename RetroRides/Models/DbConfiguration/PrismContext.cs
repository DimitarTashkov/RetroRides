using Microsoft.EntityFrameworkCore;
using RetroRides.Data.Models;
using RetroRides.Models;
using RetroRides.Models.DbConfiguration;

namespace RetroRides.Data
{
    public class PrismContext : DbContext
    {
        public PrismContext()
        {
        }

        public PrismContext(DbContextOptions<PrismContext> options)
            : base(options)
        {
        }

        // --- AUTHENTICATION (Запазваме старите) ---
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        // --- CORE BUSINESS LOGIC (Новите) ---
        public DbSet<PhotoService> PhotoServices { get; set; } 
        public DbSet<PhotoSession> PhotoSessions { get; set; } 

        // --- SHOP MODULE (Чисто новите) ---
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ВАЖНО: Промени името на базата данни на 'PhotoStudioDb'
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Настройка на Many-to-Many връзката за UserRoles (ако не е настроена автоматично)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // 2. Настройка на PhotoSession (Резервации)
            modelBuilder.Entity<PhotoSession>()
                .HasOne(s => s.User)
                .WithMany(u => u.PhotoSessions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Ако изтрием User, пазим историята на сесиите (или Cascade, ако искаш да се трият)

            modelBuilder.Entity<PhotoSession>()
                .HasOne(s => s.PhotoService)
                .WithMany(p => p.PhotoSessions)
                .HasForeignKey(s => s.PhotoServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Настройка на Магазина (OrderItems свързва Order и Product)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Ако изтрием поръчка, трием и редовете ѝ

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Не трий продукт, ако има поръчки за него!

        }
    }
}