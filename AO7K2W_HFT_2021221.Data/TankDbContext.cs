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
            Conflict russia = new Conflict() { Id = 1, NameOfConflict = "Russian Conflict", Casualties = 10000, DateOfConflict = DateTime.Parse("2001.01.13"), Winner = "Russia" };
            Conflict europe = new Conflict() { Id = 2, NameOfConflict = "European Conflict", Casualties = 4958851, DateOfConflict = DateTime.Parse("1975.05.15"), Winner = "Germany" };
            Conflict usa = new Conflict() { Id = 3, NameOfConflict = "United States of America Conflict", Casualties = 1, DateOfConflict = DateTime.Parse("2005.09.23"), Winner = "USA" };


            //----------------------------------- EUROPEAN CONFLICT ----------------------------------------
            Tank cent1 = new Tank()
            {
                Id = 1,
                ConflictId = europe.Id,
                StartOfService = DateTime.Parse("1967.01.01"),
                CrewSpace = 5,
                Eliminations = 123,
                Nickname = "Beehive",
                Model = "Centurion MK 1"
            };//1
            Tank cent2 = new Tank()
            {
                Id = 2,
                ConflictId = europe.Id,
                StartOfService = DateTime.Parse("1967.01.01"),
                CrewSpace = 5,
                Eliminations = 56,
                Nickname = "Jolly",
                Model = "Centurion MK 7/1"
            };//2
            Tank leo1 = new Tank()
            {
                Id = 3,
                ConflictId = europe.Id,
                StartOfService = DateTime.Parse("1969.05.11"),
                CrewSpace = 4,
                Eliminations = 41,
                Nickname = "Leowagen",
                Model = "Leopard 1"
            };//3
            Tank leo2 = new Tank()
            {
                Id = 4,
                ConflictId = europe.Id,
                StartOfService = DateTime.Parse("1969.05.11"),
                CrewSpace = 4,
                Eliminations = 2,
                Nickname = "Leopold",
                Model = "Leopard 1"
            };//4
            //----------------------------------- EUROPEAN CONFLICT ----------------------------------------

            //----------------------------------- RUSSIAN CONFLICT -----------------------------------------
            Tank t34_1 = new Tank()
            {
                Id = 5,
                ConflictId = russia.Id,
                StartOfService = DateTime.Parse("1942.09.01"),
                CrewSpace = 5,
                Eliminations = 51,
                Nickname = "Strong Ivan",
                Model = "T34-85"
            };//5
            Tank t34_2 = new Tank()
            {
                Id = 6,
                ConflictId = russia.Id,
                StartOfService = DateTime.Parse("1941.06.07"),
                CrewSpace = 4,
                Eliminations = 32,
                Nickname = "Vlad",
                Model = "T34(1941)"
            };//6
            Tank panther1 = new Tank()
            {
                Id = 7,
                ConflictId = russia.Id,
                StartOfService = DateTime.Parse("1951.03.12"),
                CrewSpace =6,
                Eliminations = 21,
                Nickname = "Punther",
                Model = "Panther D"
            };//7
            Tank panther2 = new Tank()
            {
                Id = 8,
                ConflictId = russia.Id,
                StartOfService = DateTime.Parse("1951.03.12"),
                CrewSpace = 6,
                Eliminations = 111,
                Nickname = "Zeskie",
                Model = "Panther A"
            };//8
            //----------------------------------- RUSSIAN CONFLICT -----------------------------------------

            //----------------------------------- USA CONFLICT ---------------------------------------------
            Tank sherman1 = new Tank()
            {
                Id = 9,
                ConflictId = usa.Id,
                StartOfService = DateTime.Parse("1950.02.17"),
                CrewSpace = 5,
                Eliminations = 11,
                Nickname = "Skye",
                Model = "M4 Sherman"
            };//9
            Tank sherman2 = new Tank()
            {
                Id = 10,
                ConflictId = usa.Id,
                StartOfService = DateTime.Parse("1947.11.12"),
                CrewSpace = 4,
                Eliminations = 7,
                Nickname = "Ratchet",
                Model = "M4A1 Sherman"
            };//10
            Tank maus = new Tank()
            {
                Id = 11,
                ConflictId = usa.Id,
                StartOfService = DateTime.Parse("1960.12.24"),
                CrewSpace = 9,
                Eliminations = 1000,
                Nickname = "Blutrünstige",
                Model = "Maus"
            };//11
            Tank panther3 = new Tank() 
            {
                Id = 12,
                ConflictId = usa.Id,
                StartOfService = DateTime.Parse("1959.08.13"),
                CrewSpace = 6,
                Eliminations = 111,
                Nickname = "Jäger der Nacht",
                Model = "Panther K"
            };//12
            //----------------------------------- USA CONFLICT ---------------------------------------------





        }
    }
}
