using System;
using Minerva.Models;

namespace Minerva.Core
{
    public class BasicLog
    {
        public static void log(Cosmetics cosmetic)
        {
            //PlaceHolder Bs until i create a logger  
            //var v = DateTime.Today - cosmetic.ShopHistory.Last();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This outfit has a shop history!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name: " + cosmetic.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ID: " + cosmetic.Id);
            Console.WriteLine("Added in " + cosmetic.Added);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This Cosmetic appeared in the shop " + cosmetic.ShopHistory.Count + " Times");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}