using System;
using System.Threading.Tasks;
using Minerva.Core;

namespace Minerva
{
    internal static class Program
    {
        private static async Task Main()
        {
            await BasicCommands.GrabOutfitsWithShopHistory();
            Console.ReadKey();
        }
    }
}

