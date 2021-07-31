using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dworkin.Interfaces;
using Dworkin.Tables.AppearanceAdjectives;
using Dworkin.Tables.Genders;
using Dworkin.Tables.Races;
using Dworkin.Utils;

namespace Dworkin.Commands
{
    public class NPCCommand : IGenerator
    {
        private Random _rng;
        private Logger _logger;

        private ITable _tableGenders;
        private ITable _tableAppearanceAdjectives;
        private ITable _tableRaces;

        public NPCCommand(Random rng, Logger logger)
        {
            _rng = rng;
            _logger = logger;

            _tableGenders = new Genders();
            _tableAppearanceAdjectives = new AppearanceAdjectives();
            _tableRaces = new Races();
        }

        private string GenerateFromATable(ITable table, string[] commands)
        {
            var randomValue = _rng.Next(table.TableSize);

            Regex re = new Regex(@"\d+");
            foreach (string element in commands)
            {
                if (re.IsMatch(element))
                {
                    randomValue = Int32.Parse(element);
                    break;
                }
            }

            if (randomValue > table.TableSize || randomValue < 0)
                return $"Provided value is out of range. Selected table has {table.TableSize} rows.";

            return $"{TableManager.Fetch(table, randomValue)}";
        }

        private async Task<string> GenerateName(string uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            
            return responseBody.TrimStart('[').TrimEnd(']').Trim('"');
        }

        public string Generate(string[] commands)
        {
            ITable genderTable = _tableGenders;
            ITable appearanceAdjectivesTable = _tableAppearanceAdjectives;
            ITable racesTable = _tableRaces;

            string gender = GenerateFromATable(genderTable, commands);
            string name = GenerateName($"https://namey.muffinlabs.com/name.json?type={gender}&with_surname=true&frequency=all").Result;
            string race = GenerateFromATable(racesTable, commands);
            string appearanceAdjective = GenerateFromATable(appearanceAdjectivesTable, commands);

            string genderPronoun = "";
            var appearanceString = "appears";

            if (gender == "female") {
                genderPronoun = "She";
            } else if (gender == "male") {
                genderPronoun = "He";
            } else {
                genderPronoun = "They";
                appearanceString = "appear";
            }

            return $">>> {name}, a {race} {gender}, stands before you. {genderPronoun} {appearanceString} {appearanceAdjective}.";
        }
    }
}