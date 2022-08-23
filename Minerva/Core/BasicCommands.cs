using System;
using System.Linq;
using System.Threading.Tasks;
using Minerva.Models;

namespace Minerva.Core
{
    public class BasicCommands
    {
        public static async Task GrabOutfitsWithShopHistory()
        {
            var list = await Requests.Connect(BaseReq.BaseOutfit);
            var cosmetics = list.Data;
            foreach (var cosmetic in cosmetics)
            {
                if (cosmetic.HasShopHistory)
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
    }
}