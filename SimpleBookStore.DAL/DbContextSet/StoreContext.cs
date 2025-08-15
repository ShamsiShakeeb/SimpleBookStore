using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleBookStore.DAL.DTO;
using SimpleBookStore.DAL.StoreEntity;

namespace SimpleBookStore.DAL.DbContextSet
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Book> Book { set; get; }
        public DbSet<Review> Review { set; get; }
        public DbSet<UserBook> User_Book { set; get; }

        public DbSet<UserBookStatsReport> UserBookStats { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserBookStatsReport>().HasNoKey().ToView(null);
        }

    }

    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("StoreConnection");

            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
