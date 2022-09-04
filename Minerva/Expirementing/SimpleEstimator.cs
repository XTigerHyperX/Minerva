using System;
using System.Collections.Generic;
using System.Linq;
using Minerva.Models;

namespace Minerva.Expirementing
{
    public class SimpleEstimator
    {
        private DateTime CurrentTime = DateTime.Today;
        
        
        public static void CalculateAvg(Cosmetics cos)
        {
            var list = DeleteRepeated(cos);
            var first = list[0];
            DateTime s = list[0];
            
            var x = list.Last();
            var b = list.First();
            double totalDays = 0;

            list.ForEach(i =>
            {
                totalDays = (s - i).TotalDays;
            });
            Console.WriteLine( totalDays / list.Count + " days");



        }
        private static List<DateTime>? DeleteRepeated(Cosmetics cos)
        {
            DateTime firstOcc = cos.ShopHistory[0];
            DateTime lastocc = firstOcc;
            List<DateTime> list = new();

            foreach (var s in cos.ShopHistory)
            {
                if (lastocc.AddDays(1) == s)
                {
                    lastocc = s;
                }
                else
                {
                    lastocc = s;
                    list?.Add(s);
                }
            }

            if (list != null)
                foreach (var x in list)
                {
                    Console.WriteLine(x);
                }

            return list;
        }
    }
}