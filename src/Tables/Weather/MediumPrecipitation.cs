using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Weather
{
    public class MediumPrecipitation : ITable
    {
        private const string _tableJson = "/Tables/TableJson/weather_medium_precipitation.json";

        public MediumPrecipitation()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}