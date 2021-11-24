using AO7K2W_HFT_2021221.Data;
using AO7K2W_HFT_2021221.Models;
using System;
using System.Linq;

namespace AO7K2W_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:26569");
            rest.Post<Conflict>(new Conflict()
            {
                NameOfConflict = "Operation Teszt Conflict",
                DateOfConflict = DateTime.Parse("2000.01.01")
            }, "conflict");
            var conflicts = rest.Get<Conflict>("conflict");
            foreach (var item in conflicts)
            {
                Console.WriteLine(item.NameOfConflict);
            }
            
        }
    }
}
