﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrnsnChecker
{
    public class JSONDataFilter
    {
        private JSONConverter.RootObjectAchievements achievements;
        private JSONConverter.RootObjectMounts mounts;
        private JSONConverter.RootObjectStatistics statistics;
        private JSONConverter.RootObjectStats stats;
        private JSONConverter.RootObjectTalents talents;
        private JSONConverter.RootObjectAudit audit;
        private JSONConverter.RootObjectItems items;

        public JSONDataFilter(JSONConverter.RootObjectAchievements _achievements, JSONConverter.RootObjectMounts _mounts, JSONConverter.RootObjectStatistics _statistics, JSONConverter.RootObjectStats _stats, JSONConverter.RootObjectTalents _talents, JSONConverter.RootObjectAudit _audit, JSONConverter.RootObjectItems _items)
        {
            achievements = _achievements;
            mounts = _mounts;
            statistics = _statistics;
            stats = _stats;
            talents = _talents;
            audit = _audit;
            items = _items;
        }

        public Dictionary<string, int> GetDungeonCount(List<int> idlist)
        {
            var dictionary = new Dictionary<string, int>();
            var dungeonStatistics = statistics.statistics.subCategories[5].subCategories[6].statistics;

            foreach (var dungeonID in dungeonStatistics)
            {
                //dictionary.Add();
                //dictionary.Add();
                //dictionary.Add();
            }

            return new Dictionary<string, int>();
        }

        public bool AchievementCompleted(int id)
        {
            return achievements.achievements.achievementsCompleted.Contains(id);
        }
        public int GearNoGemsCount()
        {
            return audit.audit.emptySockets;
        }
        public int GearTraitCount()
        {
            if (items.items.mainHand.artifactTraits.Select(x => x.rank).Sum() == 0)
            {
                if (items.items.offHand.artifactTraits.Select(x => x.rank).Sum() == 0)
                {
                    return 0;
                }

                return items.items.offHand.artifactTraits.Select(x => x.rank).Sum() - 3;
            }
            return items.items.mainHand.artifactTraits.Select(x => x.rank).Sum() - 3; //- 3 wegen relikte
        }
        public int GearBonusTraitCount()
        {
            if (items.items.mainHand.artifactTraits.Select(x => x.rank).Sum() == 0)
            {
                if (items.items.offHand.artifactTraits.Select(x => x.rank).Sum() == 0)
                {
                    return 0;
                }

                return items.items.offHand.artifactTraits.Select(x => x.rank).Sum() - 3 - 34;
            }
            return items.items.mainHand.artifactTraits.Select(x => x.rank).Sum() - 3 - 34 < 0 ? 0 : items.items.mainHand.artifactTraits.Select(x => x.rank).Sum() - 3 - 34; //- 3 wegen relikte
        }
        public int GearItemLevel()
        {
            return items.items.averageItemLevelEquipped;
        }
        public float GearItemLevelManualCalc()
        {
            var itemList = new List<JSONConverter.Item>()
            {
                //items.items.back,
                //items.items.chest,
                //items.items.feet,
                //items.items.finger1,
                //items.items.finger2,
                //items.items.hands,
                //items.items.head,
                //items.items.legs,
                //items.items.mainHand,
                //items.items.neck,
                //items.items.shoulder,
                //items.items.trinket1,
                //items.items.trinket2,
                //items.items.waist,
                //items.items.wrist,
                //items.items.offHand
            };

            var itemLevelCounter = 0.0f;

            foreach (var item in itemList)
            {
                if (item == null || item.id == null) continue;

                if (item.itemLevel == 895 && item.quality == 5) //5= legendary
                    item.itemLevel = 910;

                itemLevelCounter += item.itemLevel;
            }

            float calculatedItemLevel = Convert.ToSingle(itemLevelCounter / (float)itemList.Where(x => x != null).Count());
            return calculatedItemLevel;
        }
        public bool MountObtained(int id)
        {
            return mounts.mounts.collected.Where(x => x.itemId == id).Any();
        }
        public DateTime ArmoryLastUpdate()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(items.lastModified/1000).ToLocalTime();
            return dtDateTime;
        }
    }
}
