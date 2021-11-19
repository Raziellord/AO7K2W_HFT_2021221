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
    public class Tester
    {
        TankLogic tl;

        [SetUp]
        public void Init()
        {
            var mockTankRepo = new Mock<ITankRepository>();

            Conflict fakeConflict = new Conflict();
            fakeConflict.Id = 1;
            fakeConflict.NameOfConflict = "Conflict of Test";
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
                Conflict = fakeConflict
                },//3

                 new Tank()
                {
                Id = 2,
                ConflictId = fakeConflict.Id,
                StartOfService = DateTime.Parse("1960.12.24"),
                CrewSpace = 9,
                Eliminations = 1000,
                Nickname = "Blutrünstige",
                Model = "Maus",
                Conflict = fakeConflict
                
                }//11
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
    }
}

