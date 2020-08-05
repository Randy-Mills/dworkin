using System;
using System.Linq;
using Generator.Models;
using Toolkit.Generator;

namespace Generator.Tables.Weather
{
    public class TemperateWeather : ITable
    {
        private Percentile[] _table = {
            new Percentile(0,19,"Sunny: Features a hot, cloudless sky with an occasional light breeze."),
            new Percentile(20,44,"Sunny with cloudy periods: A warm day with a light breeze."),
            new Percentile(45,62,"Overcast: A warm day with cloud cover and an occasional light breeze."),
            new Percentile(63,75,"Light Precipitation: Roll again for light precipitation. (WIP, eventually tool will handle reroll for you.)"),
            new Percentile(76,89,"Medium Precipitation: Roll again for medium precipitation. (WIP, eventually tool will handle reroll for you.)"),
            new Percentile(90,99,"Heavy Precipitation: Roll again for heavy precipitation. (WIP, eventually tool will handle reroll for you.)")
        };

        public TemperateWeather()
        {
            Table = _table;
            Max = _table[_table.Length-1].max;
        }

        public int Max { get; set; }
        public int Min { get; set; }
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