using AO7K2W_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AO7K2W_HFT_2021221.Data
{
    public partial class TankDbContext : DbContext
    {
        public virtual DbSet<Tank> Tanks { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
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
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Attachdbfilename=|DataDirectory|\TankDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasOne(crew => crew.Tank)
                .WithMany(tank => tank.Crews)
                .HasForeignKey(crew => crew.TankId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tank>(entity =>
            {
                
                entity.HasOne(tank => tank.Conflict)
                .WithMany(conflict => conflict.Tanks)
                .HasForeignKey(tank => tank.ConflictId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

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


            //-------------------------------------CREWS ---------------------------------------------------

            Crew uk1 = new Crew() { Id = 1, Name = "George Hiller", Age = 23, Profession = "Tank Commander", Rank = "Sergeant", TankId = cent1.Id };
            Crew uk2 = new Crew() { Id = 2, Name = "James Pitsbury", Age = 31, Profession = "Tank Commander", Rank = "Major", TankId = cent2.Id };

            Crew ger1 = new Crew() { Id = 3, Name = "Ulrich Aufstadt", Age = 19, Profession = "Loader", Rank = "Cadet", TankId = leo1.Id };
            Crew ger2 = new Crew() { Id = 4, Name = "Jonah Kingerlich", Age = 25, Profession = "Gunner", Rank = "Private", TankId = leo2.Id };

            Crew rus1 = new Crew() { Id = 5, Name = "Vladimir Segerovovich", Age = 12, Profession = "Tank Commander", Rank = "General", TankId = t34_1.Id };
            Crew rus2 = new Crew() { Id = 6, Name = "Igor Taran", Age = 46, Profession = "Radioman", Rank = "Sergeant", TankId = t34_2.Id };

            Crew ger3 = new Crew() { Id = 7, Name = "Rudolf Heimlich", Age = 50, Profession = "Tank Commander", Rank = "Major", TankId = panther1.Id };
            Crew ger4 = new Crew() { Id = 8, Name = "Peter Zonstag", Age = 20, Profession = "Repairman", Rank = "Cadet", TankId = panther2.Id };

            Crew us1 = new Crew() { Id = 9, Name = "George Hiller", Age = 23, Profession = "Tank Commander", Rank = "Sergeant", TankId = sherman1.Id };
            Crew us2 = new Crew() { Id = 10, Name = "James Pitsbury", Age = 31, Profession = "Tank Commander", Rank = "Major", TankId = sherman2.Id };

            Crew maus1 = new Crew() { Id = 11, Name = "Himmler Goebbels", Age = 69, Profession = "Tank Commander", Rank = "General Major", TankId = maus.Id };
            Crew pantherk1 = new Crew() { Id = 12, Name = "Gesternvauer Karl", Age = 17, Profession = "Recon", Rank = "Private", TankId = panther3.Id };

            //-------------------------------------CREWS ---------------------------------------------------

            

            modelBuilder.Entity<Conflict>().HasData(russia, europe, usa);
            modelBuilder.Entity<Tank>().HasData(cent1, cent2, leo1, leo2, t34_1, t34_2, panther1, panther2, sherman1, sherman2, maus, panther3);
            modelBuilder.Entity<Crew>().HasData(uk1, uk2, ger1, ger2, rus1, rus2, ger3, ger4, us1, us2, maus1, pantherk1);
        }
    }
}
