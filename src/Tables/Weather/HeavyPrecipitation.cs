using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Weather
{
    public class HeavyPrecipitation : ITable
    {
        private const string _tableJson = "/Tables/TableJson/weather_heavy_precipitation.json";

        public HeavyPrecipitation()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}