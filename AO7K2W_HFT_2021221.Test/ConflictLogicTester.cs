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
    public class ConflictLogicTester
    {
        ConflictLogic cl;

        [SetUp]
        public void Init()
        {
            var mockConflictRepository = new Mock<IConflictRepository>();

            Crew fakeCrew = new Crew() { Id = 49, Name = "Himmler Goebbels", Age = 69, Profession = "Tank Commander", Rank = "General Major" };
            Crew fakeCrew2 = new Crew() { Id = 55, Name = "Caesar Schweinitz", Age = 46, Profession = "Radioman", Rank = "Lieutenant"};
            Tank fakeTank = new Tank()
            {
                Id = 9,
                StartOfService = DateTime.Parse("1951.02.17"),
                CrewSpace = 5,
                Eliminations = 111,
                Nickname = "Skye",
                Model = "M4 Sherman"
            };

            
            List<Tank> tanks = new List<Tank>();
            tanks.Add(fakeTank);
            List<Crew> crews = new List<Crew>();
            crews.Add(fakeCrew);
            crews.Add(fakeCrew2);
            fakeTank.Crews = crews;

            
            var conflicts = new List<Conflict>()
            {
                new Conflict() { Id = 1, NameOfConflict = "Russian Conflict", Casualties = 10000, DateOfConflict = DateTime.Parse("2001.01.13"), Winner = "Russia",Tanks = tanks },
                new Conflict() { Id = 2, NameOfConflict = "European Conflict", Casualties = 4958851, DateOfConflict = DateTime.Parse("1975.05.15"), Winner = "Germany",Tanks = tanks }
            }.AsQueryable();

            mockConflictRepository.Setup((t) => t.ReadAll()).Returns(conflicts);
            cl = new ConflictLogic(mockConflictRepository.Object);
        }


        [Test]
        public void ConflictsWhereAvgEliminationOver100Test()
        {
            var result = cl.ConflictsWhereAvgEliminationOver100();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConflictsWhereAvgCrewAgeOver30Test()
        {
            var result = cl.ConflictsWhereAvgCrewAgeOver30();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConflictsWhereTankHasRadiomanTest()
        {
            var result = cl.ConflictsWhereTankHasRadioman();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConflictsWhereTankServiceStartAvereageOver1950Test()
        {
            var result = cl.ConflictsWhereTankServiceStartAvereageOver1950();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConflictsWhereGeneralMajorParticipatedTest()
        {
            var result = cl.ConflictsWhereGeneralMajorParticipated();
            var expected = cl.ReadAll();
            Assert.That(result, Is.EqualTo(expected));
        }
    }

   
}
