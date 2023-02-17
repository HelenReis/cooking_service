using BreadService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreadService.Infra.Data
{
    public class BreadDataContext : DbContext, IBreadDataContext
    {
        private readonly DbContextOptions<BreadDataContext> _context;
        public BreadDataContext (DbContextOptions<BreadDataContext> options)
            : base(options)
        { }

        public DbSet<Bread> Bread { get; set; }
        public DbSet<Cheese> Cheese { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Bread>()
                .HasKey(m => m.Id);
            builder.Entity<Bread>()
                .HasOne(m => m.Cheese)
                .WithOne();

            builder.Entity<Cheese>()
                .HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

        void IBreadDataContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}