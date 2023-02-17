using BreadService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreadService.Infra.Data
{
    public interface IBreadDataContext
    {
        public DbSet<Bread> Bread { get; }
        public DbSet<Cheese> Cheese { get; }
        public void SaveChanges();
    }
}