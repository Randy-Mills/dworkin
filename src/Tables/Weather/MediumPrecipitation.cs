using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Weather
{
    public class MediumPrecipitation : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,19,"Medium Fog: Reduces visibility ranges by half, resulting in a –2 penalty on Perception checks and a –2 penalty on ranged attacks. Medium fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Medium fog occurs only when there is no or light wind."),
            new Percentile(20,29,"Heavy Fog: Obscures all vision beyond 5 feet, including darkvision. Creatures 5 feet away have concealment. Heavy fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Heavy fog occurs only when there is no or light wind."),
            new Percentile(30,34,"Light Rain:  Reduces visibility to three-quarters of the normal range, imposing a –1 penalty on Perception checks. It automatically extinguishes tiny unprotected flames (candles and the like, but not torches)."),
            new Percentile(35,99,"Rain: Reduces visibility ranges by half, resulting in a –2 penalty on Perception checks. Rain automatically extinguishes unprotected flames (candles, torches, and the like) and imposes a –2 penalty on ranged attacks.")
        };

        public MediumPrecipitation()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public Percentile[] Table { get; set; }

        public string Fetch(int position)
        {
            var response = "";
            foreach (Percentile element in Table)
            {
                if (Enumerable.Range(element.min,element.max).Contains(position))
                    response = element.value;
            }
            return response;
        }
    }
}