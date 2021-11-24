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
    public class TankLogicTester
    {
        TankLogic tl;


        [SetUp]
        public void Init()
        {
            var mockTankRepo = new Mock<ITankRepository>();

            Conflict fakeConflict = new Conflict();
            fakeConflict.Id = 1;
            fakeConflict.NameOfConflict = "Conflict of Test";
            fakeConflict.Casualties = 1;

            Crew fakeCrew = new Crew() { Id = 9, Name = "Wolf Steven", Age = 44, Profession = "Radioman", Rank = "Major" };
            List<Crew> crews = new List<Crew>();
            crews.Add(fakeCrew);

            var tanks = new List<Tank>()
            {
                 new Tank()
                {
                Id = 1,
                ConflictId = fakeConflict.Id,
                StartOfService = DateTime.Parse("1969.05.11"),
                CrewSpace = 4,
                Eliminations = 41,
                Nickname = "Leowagen",
                Model = "Leopard 1",
                Conflict = fakeConflict,
                Crews = crews

                },

                 new Tank()
                {
                Id = 2,
                ConflictId = fakeConflict.Id,
                StartOfService = DateTime.Parse("1960.12.24"),
                CrewSpace = 9,
                Eliminations = 1000,
                Nickname = "Blutrünstige",
                Model = "Maus",
                Conflict = fakeConflict,
                Crews = crews

                }
            }.AsQueryable();

            mockTankRepo.Setup((t) => t.ReadAll()).Returns(tanks);
            tl = new TankLogic(mockTankRepo.Object);
        }



        [Test]
        public void AVGElimination()
        {
            var result = tl.AVGElimination();
            Assert.That(result, Is.EqualTo(520.5));
        }


        [Test]
        public void AVGAgeEliminationByConflictTest()
        {
            
            var result = tl.TankAverageEliminationByConflict();

            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("Conflict of Test",520.5)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TanksWithRadioManTest()
        {
            var result = tl.TanksWithRadioMan();
            var expected = tl.ReadAll();

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TanksAverageServiceStartByConflictTest()
        {
            var result = tl.TankAverageStartOfServiceByConflict();

            var expected = new List
                <KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>
                ("Conflict of Test",1964.5)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TanksFromConflictsWithOneOrLessCasualtiesTest()
        {
            var result = tl.TanksFromConflictsWithOneOrLessCausalties();
            var expected = tl.ReadAll();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TanksCrewAgeAverageOver30Test()
        {
            var result = tl.TanksWhereAverageCrewAgeOver30();
            var expected = tl.ReadAll();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

