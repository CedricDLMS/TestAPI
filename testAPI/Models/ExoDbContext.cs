using Microsoft.EntityFrameworkCore;

namespace testAPI.Models
{
    public class ExoDbContext : DbContext
    {
        public ExoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Exos_API_DB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var c0 = new Client { FirstName = "Cedric", LastName ="DELMAS", ClientId = 1 };
            var c1 = new Client { FirstName = "Flo", LastName = "TOCCO", ClientId = 2 };
            var c2 = new Client { FirstName = "Oli", LastName = "KOENIG", ClientId = 3 };
            
            modelBuilder.Entity<Client>().HasData(new List<Client> { c0,c1,c2});
            base.OnModelCreating(modelBuilder);
        }
    }
}
