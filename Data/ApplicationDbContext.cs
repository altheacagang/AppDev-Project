using LaGilap.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaGilap.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<StudentVerification> StudentVerifications => Set<StudentVerification>();
        public DbSet<Stall> Stalls => Set<Stall>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Latag> Latags => Set<Latag>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            foreach (var fk in b.Model.GetEntityTypes()
                .Where(e => e.ClrType.Namespace == "LaGilap.Models")
                .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            b.Entity<StudentVerification>(e =>
            {
                e.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId);
                e.HasOne(v => v.ReviewedBy).WithMany().HasForeignKey(v => v.ReviewedById);
                e.Property(v => v.Status).HasConversion<string>().HasMaxLength(20);
            });

            b.Entity<Stall>(e =>
            {
                e.HasOne(s => s.Owner).WithMany().HasForeignKey(s => s.OwnerId);
                e.Property(s => s.Latitude).HasPrecision(9, 6);
                e.Property(s => s.Longitude).HasPrecision(9, 6);
            });

            b.Entity<Category>().HasIndex(c => c.CategoryName).IsUnique();

            b.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2);

            b.Entity<Latag>(e =>
            {
                e.HasOne(l => l.PostedBy).WithMany().HasForeignKey(l => l.PostedById);
                e.Property(l => l.Price).HasPrecision(10, 2);
            });

            b.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasOne(o => o.Student).WithMany().HasForeignKey(o => o.StudentId);
                e.Property(o => o.TotalAmount).HasPrecision(10, 2);
                e.Property(o => o.Status).HasConversion<string>().HasMaxLength(20);
            });

            b.Entity<OrderItem>(e =>
            {
                e.Property(i => i.UnitPrice).HasPrecision(10, 2);
                e.HasOne(i => i.Order).WithMany(o => o.Items)
                    .HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Cascade);
            });

            b.Entity<Review>(e =>
            {
                e.HasOne(r => r.Student).WithMany().HasForeignKey(r => r.StudentId);
                e.HasOne(r => r.Order).WithOne(o => o.Review)
                    .HasForeignKey<Review>(r => r.OrderId);
                e.HasIndex(r => r.OrderId).IsUnique();
                e.ToTable(t => t.HasCheckConstraint("CK_Review_Rating", "[Rating] BETWEEN 1 AND 5"));
            });

            b.Entity<AuditLog>()
                .HasOne(a => a.Admin).WithMany().HasForeignKey(a => a.AdminId);
        }
    }
}