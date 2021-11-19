using AO7K2W_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

            var crew = new List<Crew>()
            {
                //(╯°□°）╯︵ ┻━┻
             //CENTURION 1
             new Crew() { Id = 1, Name = "George Hiller", Age = 23, Profession = "Tank Commander", Rank = "Commander", TankId = cent1.Id },
             new Crew(){ Id = 2, Name = "Churchill  Winston", Age = 56, Profession = "Gunner", Rank = "Major", TankId = cent1.Id },
             new Crew(){ Id = 3, Name = "Peter Pettigrew", Age = 12, Profession = "Loader", Rank = "Lieutenant", TankId = cent1.Id },
             new Crew(){ Id = 4, Name = "Harry Potter", Age = 33, Profession = "Radioman", Rank = "Sergeant", TankId = cent1.Id },
             new Crew(){ Id = 5, Name = "James Cameron", Age = 25, Profession = "Driver", Rank = "Private", TankId = cent1.Id },

             //CENTURION 2 
             new Crew() { Id = 6, Name = "James Pitsbury", Age = 31, Profession = "Tank Commander", Rank = "Commander", TankId = cent2.Id },
             new Crew() { Id = 7, Name = "Sam Hotfield", Age = 27, Profession = "Gunner", Rank = "Lieutenant", TankId = cent2.Id },
             new Crew() { Id = 8, Name = "Bill  Hunter", Age = 28, Profession = "Loader", Rank = "Lieutenant", TankId = cent2.Id },
             new Crew() { Id = 9, Name = "Wolf Steven", Age = 44, Profession = "Radioman", Rank = "Major", TankId = cent2.Id },
             new Crew() { Id = 10, Name = "George Hopper", Age = 22, Profession = "Driver", Rank = "Sergeant", TankId = cent2.Id },
             //LEOPARD 1
             new Crew() { Id = 11, Name = "Ulrich Aufstadt", Age = 19, Profession = "Tank Commander", Rank = "Commander", TankId = leo1.Id },
             new Crew() { Id = 12, Name = "Bastian Veiel", Age = 21, Profession = "Gunner", Rank = "Major", TankId = leo1.Id },
             new Crew() { Id = 13, Name = "Frank Gehrig", Age = 45, Profession = "Loader", Rank = "Cadet", TankId = leo1.Id },
             new Crew() { Id = 14, Name = "Dominik Nussbaum", Age = 55, Profession = "Driver", Rank = "Cadet", TankId = leo1.Id },
             //LEOPARD 2
             new Crew() { Id = 15, Name = "Jonah Kingerlich", Age = 25, Profession = "Tank Commander", Rank = "Commander", TankId = leo2.Id },
             new Crew() { Id = 16, Name = "Casper Feigenbaum", Age = 25, Profession = "Gunner", Rank = "Major", TankId = leo2.Id },
             new Crew() { Id = 17, Name = "Lennard Gollwitzer", Age = 25, Profession = "Loader", Rank = "Private", TankId = leo2.Id },
             new Crew() { Id = 18, Name = "Marius Dischinger", Age = 25, Profession = "Driver", Rank = "Cadet", TankId = leo2.Id },
             //T34_1
             new Crew() { Id = 19, Name = "Vladimir Segerovovich", Age = 12, Profession = "Tank Commander", Rank = "General", TankId = t34_1.Id },
             new Crew() { Id = 20, Name = "Tikhonov Cheslav Grigorievich", Age = 27, Profession = "Gunner", Rank = "Major", TankId = t34_1.Id },
             new Crew() { Id = 21, Name = "Yermolovo Ikovle Vladislavovich", Age = 30, Profession = "Loader", Rank = "Lieutenant", TankId = t34_1.Id },
             new Crew() { Id = 22, Name = "Zhernakov Ruslan (Rusya) Yemelyanovich", Age = 20, Profession = "Radioman", Rank = "Lieutenant", TankId = t34_1.Id },
             new Crew() { Id = 23, Name = "Pitosin Mikhail (Misha) Aleskeevich", Age = 56, Profession = "Driver", Rank = "Lieutenant", TankId = t34_1.Id },
             //T34_2
             new Crew() { Id = 24, Name = "Igor Taran", Age = 46, Profession = "Tank Commander", Rank = "Commander", TankId = t34_2.Id },
             new Crew() { Id = 25, Name = "Arkadiy Kirillovich", Age = 44, Profession = "Gunner", Rank = "Major", TankId = t34_2.Id },
             new Crew() { Id = 26, Name = "Sobchak Kliment Ivanovich", Age = 45, Profession = "Loader", Rank = "Liuetenant", TankId = t34_2.Id },
             new Crew() { Id = 27, Name = "Muravyov Benedikt Fyodorovich", Age = 43, Profession = "Driver", Rank = "Cadet", TankId = t34_2.Id },
             //PANTHER 1
             new Crew() { Id = 28, Name = "Rudolf Heimlich", Age = 50, Profession = "Tank Commander", Rank = "General", TankId = panther1.Id },
             new Crew() { Id = 29, Name = "Claus Schönfinkel", Age = 23, Profession = "Gunner", Rank = "Major", TankId = panther1.Id },
             new Crew() { Id = 30, Name = "Sven Quint", Age = 34, Profession = "Loader", Rank = "Major", TankId = panther1.Id },
             new Crew() { Id = 31, Name = "Paul Schwarzenberger", Age = 38, Profession = "Loader", Rank = "Sergeant", TankId = panther1.Id },
             new Crew() { Id = 32, Name = "Emanuel Kratochwil", Age = 42, Profession = "Radioman", Rank = "Sergeant", TankId = panther1.Id },
             new Crew() { Id = 33, Name = "Jannik Frey", Age = 60, Profession = "Driver", Rank = "Sergeant", TankId = panther1.Id },
             //PANTHER 2
             new Crew() { Id = 34, Name = "Peter Zonstag", Age = 20, Profession = "Tank Commander", Rank = "Commander", TankId = panther2.Id },
             new Crew() { Id = 35, Name = "Tom Koch", Age = 29, Profession = "Gunner", Rank = "Major", TankId = panther2.Id },
             new Crew() { Id = 36, Name = "Willy Schmuck", Age = 31, Profession = "Loader", Rank = "Cadet", TankId = panther2.Id },
             new Crew() { Id = 37, Name = "Isaac Mallwitz", Age = 35, Profession = "Loader", Rank = "Major", TankId = panther2.Id },
             new Crew() { Id = 38, Name = "Christopher Blumhardt", Age = 41, Profession = "Radioman", Rank = "Cadet", TankId = panther2.Id },
             new Crew() { Id = 39, Name = "Arne Wolf", Age = 21, Profession = "Driver", Rank = "Private", TankId = panther2.Id },
             //SHERMAN 1
             new Crew() { Id = 40, Name = "Peter Griffin", Age = 23, Profession = "Tank Commander", Rank = "Commander", TankId = sherman1.Id },
             new Crew() { Id = 41, Name = "Christopher Matthews", Age = 32, Profession = "Gunner", Rank = "General", TankId = sherman1.Id },
             new Crew() { Id = 42, Name = "Max Powell", Age = 55, Profession = "Radioman", Rank = "Sergeant", TankId = sherman1.Id },
             new Crew() { Id = 43, Name = "Jayden Ward", Age = 24, Profession = "Loader", Rank = "Sergeant", TankId = sherman1.Id },
             new Crew() { Id = 44, Name = "Jackson Wright", Age = 26, Profession = "Driver", Rank = "Private", TankId = sherman1.Id },
             //SHERMAN 2
             new Crew() { Id = 45, Name = "Christian Griffin", Age = 31, Profession = "Tank Commander", Rank = "Commander", TankId = sherman2.Id },
             new Crew() { Id = 46, Name = "Jacob Matthews", Age = 36, Profession = "Gunner", Rank = "Private", TankId = sherman2.Id },
             new Crew() { Id = 47, Name = "Johann Marshall", Age = 33, Profession = "Loader", Rank = "Sergeant", TankId = sherman2.Id },
             new Crew() { Id = 48, Name = "Hayden Cunningham", Age = 34, Profession = "Driver", Rank = "Major", TankId = sherman2.Id },
             //MAUS
             new Crew() { Id = 49, Name = "Himmler Goebbels", Age = 69, Profession = "Tank Commander", Rank = "General Major", TankId = maus.Id },
             new Crew() { Id = 50, Name = "Kaspar Grendel", Age = 60, Profession = "Tank Commander", Rank = "Major", TankId = maus.Id },
             new Crew() { Id = 51, Name = "Philipp Fresenius", Age = 55, Profession = "Gunner", Rank = "Sergeant", TankId = maus.Id },
             new Crew() { Id = 52, Name = "Philip Pröll", Age = 50, Profession = "Gunner", Rank = "Sergeant", TankId = maus.Id },
             new Crew() { Id = 53, Name = "Eduard Gebhardt", Age = 42, Profession = "Loader", Rank = "Private", TankId = maus.Id },
             new Crew() { Id = 54, Name = "Stephen Cossmann", Age = 33, Profession = "Loader", Rank = "Sergeant", TankId = maus.Id },
             new Crew() { Id = 55, Name = "Caesar Schweinitz", Age = 46, Profession = "Radioman", Rank = "Lieutenant", TankId = maus.Id },
             new Crew() { Id = 56, Name = "Clemens Selig", Age = 40, Profession = "Driver", Rank = "Cadet", TankId = maus.Id },
             new Crew() { Id = 57, Name = "Bruno Weinmann", Age = 37, Profession = "Driver", Rank = "Major", TankId = maus.Id },
             //PANTHER 3
             new Crew() { Id = 58, Name = "Gesternvauer Karl", Age = 17, Profession = "Tank Commander", Rank = "Commander", TankId = panther3.Id },
             new Crew() { Id = 59, Name = "Theo Heydrich", Age = 17, Profession = "Gunner", Rank = "Major", TankId = panther3.Id },
             new Crew() { Id = 60, Name = "Leo Traeger", Age = 17, Profession = "Loader", Rank = "Sergeant", TankId = panther3.Id },
             new Crew() { Id = 61, Name = "Reiner Joachim", Age = 17, Profession = "Recon", Rank = "Cadet", TankId = panther3.Id },
             new Crew() { Id = 62, Name = "Raphael Hengsbach", Age = 17, Profession = "Driver", Rank = "General", TankId = panther3.Id },
             new Crew() { Id = 63, Name = "Josua Spiegelmann", Age = 17, Profession = "Repairman", Rank = "Private", TankId = panther3.Id }
             };
            //┬──┬ ノ( ゜-゜ノ)
            //-------------------------------------CREWS ---------------------------------------------------






            modelBuilder.Entity<Conflict>().HasData(russia, europe, usa);
            modelBuilder.Entity<Tank>().HasData(cent1, cent2, leo1, leo2, t34_1, t34_2, panther1, panther2, sherman1, sherman2, maus, panther3);
            modelBuilder.Entity<Crew>().HasData(crew);
        }
    }
}
