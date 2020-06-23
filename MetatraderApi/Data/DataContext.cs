using MetatraderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MetatraderApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MetaTraderInfo> MetaTraderInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
