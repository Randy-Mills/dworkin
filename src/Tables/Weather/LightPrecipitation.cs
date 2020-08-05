using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Weather
{
    public class LightPrecipitation : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,19,"Light Fog: Reduces visibility to three-quarters of the normal ranges, resulting in a –1 penalty on Perception checks and a –1 penalty on ranged attacks. Light fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Light fog occurs only when there is no or light wind."),
            new Percentile(20,39,"Medium Fog: Reduces visibility ranges by half, resulting in a –2 penalty on Perception checks and a –2 penalty on ranged attacks. Medium fog typically occurs early in the day, late in the day, or sometimes at night, but the heat of the midday usually burns it away. Medium fog occurs only when there is no or light wind."),
            new Percentile(40,74,"Drizzle: It automatically extinguishes tiny unprotected flames (candles and the like, but not torches)."),
            new Percentile(75,99,"Light Rain:  Reduces visibility to three-quarters of the normal range, imposing a –1 penalty on Perception checks. It automatically extinguishes tiny unprotected flames (candles and the like, but not torches).")
        };

        public LightPrecipitation()
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