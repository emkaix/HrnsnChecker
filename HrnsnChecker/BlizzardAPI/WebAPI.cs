using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HrnsnChecker.BlizzardAPI
{
    public class WebAPI
    {
        private const string APIkey = "sqjqux6qfmbztge4f4888wukpcutz9bm";
        private enum APIMethod
        {
            Statistics,
            Achievements,
            Profile,
            Talents,
            Stats,
            Mounts,
            Audit,
            Items
        }

        public Character Character { get; set; }

        public WebAPI(Character character)
        {
            Character = character;
        }

        private JSONConverter jsonConverter = new JSONConverter();

        public async Task<JSONConverter.RootObjectStatistics> GetCharacterStatisticsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Statistics);

            if (data == null) return null;
            return jsonConverter.ConvertJsonStatistics(data);
        }
        public async Task<JSONConverter.RootObjectAchievements> GetCharacterAchievementsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Achievements);
            if (data == null) return null;

            return jsonConverter.ConvertJsonAchievements(data);
        }
        public async Task<JSONConverter.RootObjectStats> GetCharacterStatsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Stats);

            if (data == null) return null;

            return jsonConverter.ConvertJsonStats(data);
        }
        public async Task<JSONConverter.RootObjectTalents> GetCharacterTalentsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Talents);

            if (data == null) return null;

            return jsonConverter.ConvertJsonTalents(data);
        }
        public async Task<JSONConverter.RootObjectMounts> GetCharacterMountsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Mounts);

            if (data == null) return null;

            return jsonConverter.ConvertJsonMounts(data);
        }
        public async Task<JSONConverter.RootObjectAudit> GetCharacterAuditAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Audit);

            if (data == null) return null;

            return jsonConverter.ConvertJsonAudit(data);
        }
        public async Task<JSONConverter.RootObjectItems> GetCharacterItemsAsync()
        {
            var data = await GetCharacterDataAsync(Character, APIMethod.Items);

            if (data == null) return null;

            return jsonConverter.ConvertJsonItems(data);
        }

        private async Task<string> GetCharacterDataAsync(Character character, APIMethod apimethod)
        {
            var webClient = new WebClient();
            string characterData = null;
            var method = string.Empty;

            switch (apimethod)
            {
                case APIMethod.Statistics:
                    method = "statistics";
                    break;
                case APIMethod.Achievements:
                    method = "achievements";
                    break;
                case APIMethod.Profile:
                    method = "profile";
                    break;
                case APIMethod.Talents:
                    method = "talents";
                    break;
                case APIMethod.Stats:
                    method = "stats";
                    break;
                case APIMethod.Mounts:
                    method = "mounts";
                    break;
                case APIMethod.Items:
                    method = "items";
                    break;
                case APIMethod.Audit:
                    method = "audit";
                    break;
                default:
                    method = "profile";
                    break;
            }

            try
            {
                characterData = await webClient.DownloadStringTaskAsync(new Uri($@"https://eu.api.battle.net/wow/character/{character.Server}/{character.Name}?fields={method}&locale=en_GB&apikey={APIkey}"));
            }
            catch (Exception ex)
            {
                Console.Write($"ERROR: {ex.Message}");
                return null;
            }

            return characterData;
        }

        
    }
}
