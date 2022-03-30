using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AO7K2W_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:26569");
        static void Main(string[] args)
        {

            var menu = new ConsoleMenu(args, level: 0)
                //List everything in a generic way, all instances of a type.
                .Add("Show all conflicts.", () => GetConflicts())
                .Add("Show all tanks.", () => GetTanks())
                .Add("Show all crew members.", () => GetCrews())
                //Lists just one specific instance according to id.
                .Add("Get a conflict by ID.", () => GetSingleConflict())
                .Add("Get a tank by ID.", () => GetSingleTank())
                .Add("Get a crew member by ID.", () => GetSingleCrew())
                //Inserts
                .Add("Insert a conflict.", () => InsertConflict())
                .Add("Insert a tank.", () => InsertTank())
                .Add("Insert a crew member.", () => InsertCrew())
                //Updates
                .Add("Update  a conflict.", () => UpdateConflict())
                .Add("Update a tank.", () => UpdateTank())
                .Add("Update a crew member.", () => UpdateCrew())
                //Deletes
                .Add("Delete a conflict.", () => DeleteConflict())
                .Add("Delete a tank.", () => DeleteTank())
                .Add("Delete a crew member.", () => DeleteCrew())

                //Non cruds

                //Conflicts
                .Add("List all conflicts where the average elmination is over 100.", () => ConflictsWhereAvgElOver100())
                .Add("List all conflicts where the average crew age is over 30.", () => ConflictsWhereAvgAgeOver30())
                .Add("List all conflicts where a tank has a radioman.", () => ConflictsWhereTankHasRadioman())
                .Add("List all conflicts where the tanks' service start's year average is over 1950", () => ConflictsWhereServiceStartAvgOver1950())
                .Add("List all conflicts where a General Major participated", () => ConflictsWhereGeneralMajorParticipated())

                //Tanks
                .Add("List the tanks' average elimination by conflicts.", () => TankAvgElByConf())
                .Add("List the tanks with radiomen", () => TanksWithRadioman())
                .Add("List the tanks' average start of service by conflicts.", () => TanksAvgStartOfServByConf())
                .Add("List the tanks from conflicts with less than 1 casualties.", () => TanksFromConflictsOneOrLessCasualties())
                .Add("List the tanks where the crews' average age is over 30.", () => TanksWhereCrewAgeOver30())

                //Crews
                .Add("List the crews' average age by tanks", () => AvgAgeByTank())
                .Add("List crews' oldest person by tanks", () => OldestAgeByTank())
                .Add("List crews who were in tanks which started service after 1950", () => CrewsAfter1950Tanks())
                .Add("List crews where the conflict winner is the USA", () => CrewsWhereUsaWinner())
                .Add("List crews who participated in the Russian Conflict.", () => CrewsParticipatedRussia())

                //Exit
                .Add("Exit", () => Environment.Exit(0))
                .Configure(c =>
               {
                   c.Selector = "-=>";
                   c.EnableFilter = false;
                   c.Title = " Database of the world's military";
                   c.EnableWriteTitle = true;
               });
            menu.Show();
        }

        private static void CrewsParticipatedRussia()
        {
            Console.Clear();
            var crews = rest.Get<Crew>("/stat/crewswhoparticipatedinrussianconflict");
            foreach (var item in crews)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void CrewsWhereUsaWinner()
        {
            Console.Clear();
            var crews = rest.Get<Crew>("/stat/crewswhereconflictwinnerusa");
            foreach (var item in crews)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void CrewsAfter1950Tanks()
        {
            Console.Clear();
            var crews = rest.Get<Crew>("/stat/crewsafter1950tanks");
            foreach (var item in crews)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void OldestAgeByTank()
        {
            Console.Clear();
            var crews = rest.Get<KeyValuePair<string,double>>("/stat/oldestagebytank");
            foreach (var item  in crews)
            {
                Console.WriteLine("Tank:"+ item.Key + "\nAge:"+ item.Value);
            }
            Console.ReadLine();
        }

        private static void AvgAgeByTank()
        {
            Console.Clear();
            var crews = rest.Get<KeyValuePair<string, double>>("/stat/avgagebytank");
            foreach (var item in crews)
            {
                Console.WriteLine("Tank:" + item.Key + "\nAge:" + item.Value);
            }
            Console.ReadLine();
        }

        private static void TanksWithRadioman()
        {
            Console.Clear();
            var tanks = rest.Get<Tank>("/stat/tankswithradioman");
            foreach (var item in tanks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void TanksWhereCrewAgeOver30()
        {
            Console.Clear();
            var tanks = rest.Get<Tank>("/stat/tankswhereaveragecrewageover30");
            foreach (var item in tanks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void TanksFromConflictsOneOrLessCasualties()
        {
            Console.Clear();
            var tanks = rest.Get<Tank>("/stat/tanksfromconflictswithoneorlesscasusalties");
            foreach (var item in tanks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void TanksAvgStartOfServByConf()
        {
            Console.Clear();
            var tanks = rest.Get<KeyValuePair<string,double>>("/stat/tankaveragestartofservicebyconflict");
            foreach (var item in tanks)
            {
                Console.WriteLine("Tank: "+ item.Key + "\n" +"Start of service: " +item.Value);
            }
            Console.ReadLine();
        }

        private static void TankAvgElByConf()
        {
            Console.Clear();
            var tanks = rest.Get<KeyValuePair<string, double>>("/stat/tankaverageeliminationbyconflict");
            foreach (var item in tanks)
            {
                Console.WriteLine("Tank: " + item.Key + "\n" + "Average eliminations: " + item.Value);
            }
            Console.ReadLine();
        }

        private static void ConflictsWhereGeneralMajorParticipated()
        {
            Console.Clear();
            var conflicts = rest.Get<Conflict>("/stat/conflictswheregeneralmajorparticipated");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void ConflictsWhereServiceStartAvgOver1950()
        {
            Console.Clear();
            var conflicts = rest.Get<Conflict>("/stat/conflictswheretankservicestartaverageover1950");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void ConflictsWhereTankHasRadioman()
        {
            Console.Clear();
            var conflicts = rest.Get<Conflict>("/stat/conflictswheretankhasradioman");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void ConflictsWhereAvgAgeOver30()
        {
            Console.Clear();
            var conflicts = rest.Get<Conflict>("/stat/conflictswhereavgcrewageover30");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void ConflictsWhereAvgElOver100()
        {
            Console.Clear();
             var conflicts = rest.Get<Conflict>("/stat/conflictswhereavgeliminationover100");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void DeleteCrew()
        {
            Console.Clear();
            Console.WriteLine("Please give the id of the crew member you wish to delete!");

            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }
            rest.Delete<Crew>(id, "crew");
            Console.WriteLine("Succesful deletion!");
            Console.ReadLine();
        }

        private static void DeleteTank()
        {
            Console.Clear();
            Console.WriteLine("Please give the id of the tank you wish to delete!");

            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }
            rest.Delete<Tank>(id, "tank");
            Console.WriteLine("Succesful deletion!");
            Console.ReadLine();
        }

        private static void DeleteConflict()
        {
            Console.Clear();
            Console.WriteLine("Please give the id of the conflict you wish to delete!");

            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
            }
            rest.Delete<Conflict>(id,"conflict");
            Console.WriteLine("Succesful deletion!");
            Console.ReadLine();
        }

        private static void UpdateCrew()
        {
            Console.Clear();
            var crew = new Crew();
            Console.WriteLine("Please give the parameters to the crew member separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \nID of tank, Name, Profession, Age, Rank.");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if (lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }

            else if (lines.Length == 5)
            {
                crew.TankId = int.Parse(lines[0]);
                crew.Name = lines[1];
                crew.Profession = lines[2];
                crew.Age = int.Parse(lines[3]);
                crew.Rank = lines[4];

                rest.Put<Crew>(crew, "crew");
                Console.WriteLine("Crew successfully updated!");
            }
            else
            {
                Console.WriteLine("You probably gave too many or too few parameters, please check it again.");
            }

            Console.ReadLine();
        }

        private static void UpdateTank()
        {
            Console.Clear();
            var tank = new Tank();
            Console.WriteLine("Please give the parameters to the Tank separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \nID of Conflict, Model of the tank, Crew space, Start of service, ");
            Console.WriteLine("Other optional parameters: Nickname, Eliminations");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if (lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }
            else if (lines.Length == 4)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                rest.Put<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully updated!");
            }
            else if (lines.Length == 5)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                tank.Nickname = lines[4];
                rest.Put<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully updated!");

            }
            else if (lines.Length == 6)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                tank.Nickname = lines[4];
                tank.Eliminations = int.Parse(lines[5]);
                rest.Put<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully updated!");
            }
            else
            {
                Console.WriteLine("You probably gave too many  or too few parameters, please check it again.");
            }

            Console.ReadLine();
        }

        private static void UpdateConflict()
        {
            Console.Clear();
            var conf = new Conflict();
            Console.WriteLine("Please give the parameters to the conflict separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \n  Name of the conflict, Date of the conflict in YYYY.MM.DD format.");
            Console.WriteLine("Other optional parameters: Casualties, Winners");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if (lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }
            else if (lines.Length == 2)
            {

                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                rest.Put<Conflict>(conf, "conflict");
                Console.WriteLine("Successful update!");
            }
            else if (lines.Length == 3)
            {

                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                conf.Casualties = int.Parse(lines[2]);
                rest.Put<Conflict>(conf, "conflict");
                Console.WriteLine("Successful update!");
            }
            else if (lines.Length == 4)
            {

                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                conf.Casualties = int.Parse(lines[2]);
                conf.Winner = lines[3];
                rest.Put<Conflict>(conf, "conflict");
                Console.WriteLine("Successful update!");
            }
            else
            {
                Console.WriteLine("You probably gave too many or too few  parameters, please check it again.");
            }
            
            Console.ReadLine();
        }

        private static void InsertCrew()
        {
            Console.Clear();
            var crew = new Crew();
            Console.WriteLine("Please give the parameters to the crew member separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \nID of tank, Name, Profession, Age, Rank.");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if (lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }
            
            else if (lines.Length == 5)
            {
                crew.TankId = int.Parse(lines[0]);
                crew.Name = lines[1];
                crew.Profession = lines[2];
                crew.Age = int.Parse(lines[3]);
                crew.Rank = lines[4];
                
                rest.Post<Crew>(crew, "crew");
                Console.WriteLine("Crew successfully inserted!");
            }
            else
            {
                Console.WriteLine("You probably gave too many  or to few parameters, please check it again.");
            }
            
            Console.ReadLine();
        }

        private static void InsertTank()
        {
            Console.Clear();
            var tank = new Tank();
            Console.WriteLine("Please give the parameters to the Tank separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \nID of conflict, Model of the tank, Crew space, Start of service, ");
            Console.WriteLine("Other optional parameters: Nickname, Eliminations");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if (lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }
            else if (lines.Length == 4)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                rest.Post<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully inserted!");
            }
            else if (lines.Length == 5)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                tank.Nickname = lines[4];
                rest.Post<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully inserted!");

            }
            else if (lines.Length == 6)
            {
                tank.ConflictId = int.Parse(lines[0]);
                tank.Model = lines[1];
                tank.CrewSpace = int.Parse(lines[2]);
                tank.StartOfService = DateTime.Parse(lines[3]);
                tank.Nickname = lines[4];
                tank.Eliminations = int.Parse(lines[5]);
                rest.Post<Tank>(tank, "tank");
                Console.WriteLine("Tank successfully inserted!");
            }
            else
            {
                Console.WriteLine("You probably gave too many  or too few parameters, please check it again.");
            }
            
            Console.ReadLine();
        }

        private static void InsertConflict()
        {
            Console.Clear();
            var conf = new Conflict();
            Console.WriteLine("Please give the parameters to the conflict separated by #-s!");
            Console.WriteLine("You most provide the following parameters: \n  Name of the conflict, Date of the conflict in YYYY.MM.DD format.");
            Console.WriteLine("Other optional parameters: Casualties, Winners");
            string line = Console.ReadLine();
            string[] lines = line.Split('#');
            if( lines == null)
            {
                Console.WriteLine("Please provide data next time!");
            }
            else if( lines.Length == 2)
            {
                
                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                rest.Post<Conflict>(conf, "conflict");
            }
            else if( lines.Length == 3)
            {
                
                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                conf.Casualties = int.Parse(lines[2]);
                rest.Post<Conflict>(conf, "conflict");

            }
            else if(lines.Length == 4)
            {
                
                conf.NameOfConflict = lines[0];
                conf.DateOfConflict = DateTime.Parse(lines[1]);
                conf.Casualties = int.Parse(lines[2]);
                conf.Winner = lines[3];
                rest.Post<Conflict>(conf, "conflict");
            }
            else
            {
                Console.WriteLine("You probably gave too many or too few  parameters, please check it again.");
            }
            Console.WriteLine("Successful insertion!");
            Console.ReadLine();
            
        }

        private static void GetSingleCrew()
        {
            Console.Clear();
            Console.WriteLine("Whats the ID of the crew member you are looking for?");
            int id = int.Parse(Console.ReadLine());
            var crew = rest.Get<Crew>(id,"crew");
            if (crew != null)
            {
                Console.WriteLine(crew.ToString());
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadLine();
        }

        private static void GetSingleTank()
        {
            Console.Clear();
            Console.WriteLine("Whats the ID of the tank you are looking for?");
            int id = int.Parse(Console.ReadLine());
            var tank = rest.Get<Tank>(id, "tank");
            if (tank != null)
            {
                Console.WriteLine(tank.ToString());
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadLine();
        }

        private static void GetSingleConflict()
        {
            Console.Clear();
            Console.WriteLine("Whats the ID of the conflict you are looking for?");
            int id = int.Parse(Console.ReadLine());
            var conflict = rest.Get<Conflict>(id,"conflict");
            if(conflict != null)
            {
                Console.WriteLine(conflict.ToString());
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadLine();
        }

        private static void GetCrews()
        {
            Console.Clear();

            var crews = rest.Get<Crew>("crew");

            foreach (var item in crews)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void GetTanks()
        {
            Console.Clear();

            var tanks = rest.Get<Tank>("tank");

            foreach (var item in tanks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        private static void GetConflicts()
        {
            Console.Clear();

            var conflicts = rest.Get<Conflict>("conflict");

            foreach (var item in conflicts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
