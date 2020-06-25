using MetatraderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MetatraderApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TbTimeFrameM5> TbTimeFrameM5 { get; set; }

        public DbSet<TbTimeFrameM10> TbTimeFrameM10 { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TbTimeFrameM5>()
                .HasKey(mt => new {mt.Date , mt.Symbol });
        }
    }
}
