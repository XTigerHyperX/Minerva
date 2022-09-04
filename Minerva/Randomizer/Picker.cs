using System;
using System.Collections.Generic;

namespace Minerva.Randomizer
{
    public class Picker
    {
        public static int PickRandom(List<string> list)
        {
            Random random = new();
            int val = random.Next(list.Count);
            return val;
        }
    }
}