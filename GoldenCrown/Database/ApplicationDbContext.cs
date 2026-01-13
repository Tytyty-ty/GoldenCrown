using GoldenCrown.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenCrown.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builed = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = builed.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>().ToTable("users");
            userEntity.HasKey(u => u.Id);
            userEntity.Property(u => u.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            userEntity.Property(u => u.Name)
                .HasColumnName("name")
                .IsRequired();
            userEntity.Property(u => u.Login)
                .HasColumnName("login")
                .IsRequired();
            userEntity.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired();

            var accountEntity = modelBuilder.Entity<Account>().ToTable("accounts");
            accountEntity.HasKey(a => a.AccountId);
            accountEntity.Property(a => a.AccountId)
                .HasColumnName("account_id")
                .UseIdentityColumn();
            accountEntity.Property(a => a.Balance)
                .HasColumnName("id")
                .IsRequired();
            accountEntity.Property(a => a.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            accountEntity.HasOne<User>()
                .WithOne()
                .HasForeignKey<Account>(a => a.UserId);

            var sessionEntity = modelBuilder.Entity<Session>().ToTable("sessions");
            sessionEntity.HasKey(s => s.UserId);
            sessionEntity.Property(s => s.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            sessionEntity.HasOne<User>()
                .WithOne()
                .HasForeignKey<Session>(s => s.UserId);
            sessionEntity.Property(s => s.Token)
                .HasColumnName("token")
                .IsRequired();
            sessionEntity.Property(s => s.ExpiresAt)
                .HasColumnName("expires_at")
                .IsRequired();

            var transactionEntity = modelBuilder.Entity<Transaction>().ToTable("transactions");
            transactionEntity.HasKey(t => t.Id);
            transactionEntity.Property(t => t.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            transactionEntity.Property(t => t.SenderAccountId)
                .HasColumnName("sender_account_id")
                .IsRequired();
            transactionEntity.Property(t => t.ReceiverAccountId)
                .HasColumnName("receiver_account_id")
                .IsRequired();
            transactionEntity.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            transactionEntity.Property(t => t.Amount)
                .HasColumnName("amount")
                .HasPrecision(18, 2)
                .IsRequired();

        }
    }
}