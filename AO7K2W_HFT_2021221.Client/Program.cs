﻿using AO7K2W_HFT_2021221.Data;
using System;

namespace AO7K2W_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TankDbContext();

            Console.WriteLine("----Conflicts----");
            foreach (var conflict in ctx.Conflicts)
            {
                Console.WriteLine(conflict.NameOfConflict);
            }
            Console.WriteLine("----Tanks----");
            foreach (var tank in ctx.Tanks)
            {
                Console.WriteLine(tank.Nickname);
            }
            Console.WriteLine("----Crews----");
            foreach (var crew in ctx.Crews)
            {
                Console.WriteLine(crew.Name);
            }
            Console.ReadLine();
        }
    }
}
