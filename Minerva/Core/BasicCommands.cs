using System;
using System.Threading.Tasks;
using Minerva.Models;
using Logger = Minerva.Core.Logger;


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
                    BasicLog.log(cosmetic);
                }
            }
        }
    }
}