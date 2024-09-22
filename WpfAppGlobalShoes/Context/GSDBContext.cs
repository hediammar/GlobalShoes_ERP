using Microsoft.EntityFrameworkCore;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes.Context
{
    public class GSDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Sale> Sales { get; set; } // Sales table
        public DbSet<Client> Clients { get; set; } // Client table
        public DbSet<Charge> Charges { get; set; } // Charges table

        public GSDBContext(DbContextOptions<GSDBContext> options)
            : base(options)
        {
        }

        public GSDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .IsRequired();

                entity.Property(e => e.Color)
                    .HasMaxLength(50);

                entity.Property(e => e.Material)
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.ManufacturingDate)
                    .IsRequired();

                entity.Property(e => e.WarrantyPeriod)
                    .IsRequired();
            });

            // Configure Inventory entity
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.ProductID);

                entity.Property(e => e.QuantityInStock)
                    .IsRequired();

                entity.Property(e => e.LastRestockDate)
                    .IsRequired();

                entity.Property(e => e.MinimumStockLevel)
                    .IsRequired();

                entity.HasOne(e => e.Product)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(e => e.ProductID);
            });

            // Configure Employee entity
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Department)
                    .HasMaxLength(50);

                entity.Property(e => e.HireDate)
                    .IsRequired();

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AddressLine)
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasMaxLength(50);

                entity.Property(e => e.SupervisorID)
                    .HasColumnName("SupervisorID");

                entity.Property(e => e.EmploymentStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(e => e.Charges)
          .WithOne(c => c.Employee)
          .HasForeignKey(c => c.EmployeeID)
          .OnDelete(DeleteBehavior.Cascade);
            });

            // User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);

                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(u => u.Employee)
                    .WithMany()
                    .HasForeignKey(u => u.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Sale entity configuration
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleID);

                entity.Property(s => s.SaleDate)
                    .IsRequired();

                entity.Property(s => s.QuantitySold)
                    .IsRequired();

                entity.Property(s => s.UnitPrice)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(s => s.TotalPrice)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .ValueGeneratedOnAddOrUpdate();

                // Foreign key to Product
                entity.HasOne(s => s.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(s => s.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);

                // Foreign key to Client
                entity.HasOne(s => s.Client)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(s => s.ClientID)
                    .OnDelete(DeleteBehavior.Cascade);

                // Foreign key to Employee (the logged-in employee)
                entity.HasOne(s => s.Employee)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(s => s.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Charge entity configuration
            modelBuilder.Entity<Charge>(entity =>
            {
                entity.HasKey(c => c.ChargeID);

                entity.Property(c => c.ChargeType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(c => c.ChargeDate)
                    .IsRequired();

                entity.Property(c => c.Description)
                    .HasMaxLength(200);

                entity.Property(c => c.PaidStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                // Nullable due to being optional
                entity.Property(c => c.DueDate)
                    .IsRequired(false); // Set as optional

                // Nullable due to being optional
                entity.Property(c => c.PaymentDate)
                    .IsRequired(false); // Set as optional

                // Foreign key to Employee
                entity.HasOne(c => c.Employee)
                    .WithMany(e => e.Charges)
                    .HasForeignKey(c => c.EmployeeID)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-NOH724N;Database=GSDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
