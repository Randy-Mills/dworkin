using System;
using System.Text.RegularExpressions;
using Generator.Tables.AppearanceAdjectives;
using Generator.Tables.Genders;
using Generator.Tables.Names;
using Generator.Tables.Races;
using Generator.Utils;
using Toolkit.Generator;

namespace Generator.Commands
{
    public class NPCCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        public NPCCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;
        }

        private string GenerateFromATable(ITable table, string[] commands)
        {
            var randomValue = _rng.Next(table.Max);

            Regex re = new Regex(@"\d+");
            foreach (string element in commands)
            {
                if (re.IsMatch(element))
                {
                    randomValue = Int32.Parse(element);
                    break;
                }
            }

            if (randomValue > table.Max || randomValue < table.Min)
                return $"Provided value is out of range. Selected table has {table.Max} rows.";

            return $"{table.Fetch(randomValue)} ({randomValue})";
        }

        public string Generate(string[] commands)
        {
            ITable genderTable = new Genders();
            ITable appearanceAdjectivesTable = new AppearanceAdjectives();
            ITable namesTable = new Names();
            ITable racesTable = new Races();

            string name = GenerateFromATable(namesTable, commands);
            string gender = GenerateFromATable(genderTable, commands);
            string race = GenerateFromATable(racesTable, commands);
            string appearanceAdjective = GenerateFromATable(appearanceAdjectivesTable, commands);

            string genderPronoun = "";

            if (gender.Contains("female")) {
                genderPronoun = "She";
            } else if (gender.Contains("male")) {
                genderPronoun = "He";
            } else {
                genderPronoun = "They";
            }

            return $"{name}, a {gender} {race}, stands before you. {genderPronoun} appears {appearanceAdjective}.";
        }
    }
}