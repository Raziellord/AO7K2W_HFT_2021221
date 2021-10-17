using AO7K2W_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AO7K2W_HFT_2021221.Data
{
    public partial class TankDbContext : DbContext
    {
        public virtual DbSet<Tank> Tank { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Conflict> Conflicts { get; set; }
        public TankDbContext()
        {
            this.Database.EnsureCreated();
        }

        public TankDbContext(DbContextOptions<TankDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\TankDb.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
