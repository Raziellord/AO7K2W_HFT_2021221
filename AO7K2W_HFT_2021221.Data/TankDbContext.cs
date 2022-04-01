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


            modelBuilder.Entity<Crew>(crew => crew
           .HasOne(crew => crew.Tank)
           .WithMany(tank => tank.Crews)
           .HasForeignKey(crew => crew.TankId)
           .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Tank>(tank => tank
           .HasOne(tank => tank.Conflict)
           .WithMany(conflict => conflict.Tanks)
           .HasForeignKey(tank => tank.ConflictId)
           .OnDelete(DeleteBehavior.Cascade));

            

            //ConflictId#NameOfConflict#DateOfConflictYYYY*MM*DD format#Casualties#Winner#
            modelBuilder.Entity<Conflict>().HasData(new Conflict[]
            {
            new Conflict("1#Russian Conflict#2001*01*13#10000#Russia"),
            new Conflict("2#European Conflict#1975*05*15#4958851#Germany"),
            new Conflict("3#Pacific Theater#2005*09*23#1#USA")
            });


            //TankId#Model#Nickname#Eliminations#CrewSpace#StartOfSerivce YYYY*MM*DD#ConflictId#
            //Russian id : 1 || European id : 2 || Pacific id : 3
            modelBuilder.Entity<Tank>().HasData(new Tank[]
            {
                new Tank("1#Centurion MK1#Beehive#123#5#1967*01*01#2"),
                new Tank("2#Centurion 7/1#Jolly#56#5#1967*01*01#2"),

                new Tank("3#Leopard 1#LeoWagen#41#4#1969*05*11#2"),
                new Tank("4#Leopard 1#Leopold#2#4#1969*05*11#2"),


                new Tank("5#T34-85#Strong Ivan#51#5#1942*09*01#1"),
                new Tank("6#T34(1941)#Vlad#32#4#1941*06*07#1"),

                new Tank("7#Panther D#Punther#21#6#1951*03*12#1"),
                new Tank("8#Panther A#Zeskie#111#6#1951*03*12#1"),



                new Tank("9#M4 Sherman#Skye#11#5#1950*02*17#3"),
                new Tank("10#M4A1 Sherman#Ratchet#7#4#1947*11*12#3"),

                new Tank("11#Maus#Blutrünstige#1000#9#1960*12*24#3"),
                new Tank("12#Panther K#Jäger der Nacth#11123#6#1959*08*13#3")


            });

            //-------------------------------------CREWS ---------------------------------------------------
            modelBuilder.Entity<Crew>().HasData(new Crew[]
            {
                
                //1
                new Crew("1#George Hiller#Tank Commander#23#Commander#1"),
                new Crew("2#Churchill Winston#Gunner#57#Major#1"),
                new Crew("3#Peter Pettigrew#Loader#12#Lieutenant#1"),
                new Crew("4#Harry Potter#Radioman#27#Sergeant#1"),
                new Crew("5#James Cameron#Driver#25#Private#1"),

                //2
                new Crew("6#James Pitsbury#Tank Commander#31#Commander#2"),
                new Crew("7#Sam Hotfield#Gunner#27#Lieutenant#2"),
                new Crew("8#Bill Hunter#Loader#28#Lieutenant#2"),
                new Crew("9#Wolf Steven#Radioman#44#Major#2"),
                new Crew("10#George Hopper#Driver#22#Sergeant#2"),

                //3
                new Crew("11#Ulrich Aufstadt#Tank Commander#19#Commander#3"),
                new Crew("12#Bastian Veiel#Gunner#21#Major#3"),
                new Crew("13#Frank Gehrig#Loader#45#Cadet#3"),
                new Crew("14#Dominik Nussbaum#Driver#55#Cadet#3"),

                //4
                new Crew("15#Jonah Kingerlich#Tank Commander#25#Commander#4"),
                new Crew("16#Casper Feigenbaum#Gunner#25#Major#4"),
                new Crew("17#Lennard Gollwitzer#Loader#25#Private#4"),
                new Crew("18#Marius Dischinger#Driver#25#Cadet#4"),

                //5
                new Crew("19#Vladimir Segerovovich#Tank Commander#12#General#5"),
                new Crew("20#Tikhonov Cheslav Grigorievich#Gunner#27#Major#5"),
                new Crew("21#Yermolovo Ikovle Vladislavovich#Loader#30#Lieutenant#5"),
                new Crew("22#Zhernakov Ruslan (Rusya) Yemelyanovich#Radioman#20#Lieutenant#5"),
                new Crew("23#Pitosin Mikhail (Misha) Aleskeevich#Driver#56#Lieutenant#5"),
                //6
                new Crew("24#Igor Taran#Tank Commander#46#Commander#6"),
                new Crew("25#Arkadiy Kirillovich#Gunner#44#Major#6"),
                new Crew("26#Sobchak Kliment Ivanovich#Loader#45#Liuetenant#6"),
                new Crew("27#Muravyov Benedikt Fyodorovich#Driver#43#Cadet#6"),

                //7
                 new Crew("28#Rudolf Heimlich#Tank Commander#50#General#7"),
                 new Crew("29#Claus Schönfinkel#Gunner#23#Major#7"),
                 new Crew("30#Sven Quint#Loader#34#Major#7"),
                 new Crew("31#Paul Schwarzenberger#Loader#38#Sergeant#7"),
                 new Crew("32#Emanuel Kratochwil#Radioman#42#Sergeant#7"),
                 new Crew("33#Jannik Frey#Driver#60#Sergeant#7"),

                 //8
                 new Crew("34#Peter Zonstag#Tank Commander#20#Commander#8"),
                 new Crew("35#Tom Koch#Gunner#29#Major#8"),
                 new Crew("36#Willy Schmuck#Loader#31#Cadet#8"),
                 new Crew("37#Isaac Mallwitz#Loader#35#Major#8"),
                 new Crew("38#Christopher Blumhardt#Radioman#41#Cadet#8"),
                 new Crew("39#Arne Wolf#Driver#21#Private#8"),

                 //9
                 new Crew("40#Peter Griffin#Tank Commander#23#Commander#9"),
                 new Crew("41#Christopher Matthews#Gunner#32#General#9"),
                 new Crew("42#Max Powell#Radioman#55#Sergeant#9"),
                 new Crew("43#Jayden Ward#Loader#24#Sergeant#9"),
                 new Crew("44#Jackson Wright#Driver#26#Private#9"),

                 //10
                 new Crew("45#Christian Griffin#Tank Commander#31#Commander#10"),
                 new Crew("46#Jacob Matthews#Gunner#36#Private#10"),
                 new Crew("47#Johann Marshall#Loader#33#Sergeant#10"),
                 new Crew("48#Hayden Cunningham#Driver#34#Major#10"),

                 //11
                 new Crew("49#Himmler Goebbels#Tank Commander#69#General Major#11"),
                 new Crew("50#Kaspar Grendel#Tank Commander#60#Major#11"),
                 new Crew("51#Philipp Fresenius#Gunner#55#Sergeant#11"),
                 new Crew("52#Philip Pröll#Gunner#50#Sergeant#11"),
                 new Crew("53#Eduard Gebhardt#Loader#42#Private#11"),
                 new Crew("54#Stephen Cossmann#Loader#33#Sergeant#11"),
                 new Crew("55#Caesar Schweinitz#Radioman#46#Lieutenant#11"),
                 new Crew("56#Clemens Selig#Driver#40#Cadet#11"),
                 new Crew("57#Bruno Weinmann#Driver#37#Major#11"),
                 //12
                 new Crew("58#Gesternvauer Karl#Tank Commander#17#Commander#12"),
                 new Crew("59#Theo Heydrich#Gunner#17#Major#12"),
                 new Crew("60#Leo Traeger#Loader#17#Sergeant#12"),
                 new Crew("61#Reiner Joachim#Recon#17#Cadet#12"),
                 new Crew("62#Raphael Hengsbach#Driver#17#General#12"),
                 new Crew("63#Josua Spiegelmann#Repairman#17#Private#12"),
            });
            //┬──┬ ノ( ゜-゜ノ)
           




        }
    }
}
