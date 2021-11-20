using System;
using System.Collections.Generic;
using System.Linq;
using AO7K2W_HFT_2021221.Logic;
using AO7K2W_HFT_2021221.Models;
using AO7K2W_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace AO7K2W_HFT_2021221.Test
{
    [TestFixture]
    public class CrewLogicTester
    {
        CrewLogic cl;

        [SetUp]
        public void Init()
        {
            var mockCrewRepository = new Mock<ICrewRepository>();
            Conflict fakeConflict = new Conflict();
            fakeConflict.Id = 1;
            fakeConflict.NameOfConflict = "Russian Conflict";
            fakeConflict.DateOfConflict = DateTime.Parse("2021.11.19");
            fakeConflict.Winner = "USA";


            Tank fakeTank = new Tank();
            fakeTank.Id = 1;
            fakeTank.Nickname = "Tesztertank";
            fakeTank.StartOfService = DateTime.Parse("2021.11.19");
            fakeTank.CrewSpace = 5;
            fakeTank.Model = "Teszt";

            List<Tank> list = new List<Tank>();
            list.Add(fakeTank);

            fakeConflict.Tanks = list;
            fakeTank.Conflict = fakeConflict;

            var crews = new List<Crew>()
            {
             new Crew() { Id = 1, Name = "George Hiller", Age = 23, Profession = "Tank Commander", Rank = "Commander", TankId = fakeTank.Id,Tank = fakeTank },
             new Crew(){ Id = 2, Name = "Churchill  Winston", Age = 56, Profession = "Gunner", Rank = "Major", TankId = fakeTank.Id,Tank = fakeTank },
             new Crew(){ Id = 3, Name = "Peter Pettigrew", Age = 12, Profession = "Loader", Rank = "Lieutenant", TankId = fakeTank.Id,Tank = fakeTank },
             new Crew(){ Id = 4, Name = "Harry Potter", Age = 33, Profession = "Radioman", Rank = "Sergeant", TankId = fakeTank.Id ,Tank = fakeTank},
             new Crew(){ Id = 5, Name = "James Cameron", Age = 25, Profession = "Driver", Rank = "Private", TankId = fakeTank.Id ,Tank = fakeTank},
            }.AsQueryable();
            mockCrewRepository.Setup((t) => t.ReadAll()).Returns(crews);
            cl = new CrewLogic(mockCrewRepository.Object);
        }

        [Test]
        public void AVGAgeTest()
        {
            var result = cl.AVGAgeByTank();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string,double>
                ("Tesztertank",29.8)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MaxAgeByTankTest()
        {
            var result = cl.OldestAgeByTank();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string,double>
                ("Tesztertank",56)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Crew1950Test()
        {
            var result = cl.CrewsAfter1950Tanks();

            var expected = cl.ReadAll();

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void CrewsWhereConflictWinnerUSATest()
        {
            var result = cl.CrewsWhereConflictWinnerUSA();

            var expected = cl.ReadAll();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CrewsWhoParticipatedInRussiaTest()
        {
            var result = cl.CrewsWhoParticipatedInRussianConflict();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
