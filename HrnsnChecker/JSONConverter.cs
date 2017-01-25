using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HrnsnChecker
{
    public class JSONConverter
    {
        #region Rootobjects Statistics
        public class Statistic2
        {
            public int id { get; set; }
            public string name { get; set; }
            public long quantity { get; set; }
            public object lastUpdated { get; set; }
            public bool money { get; set; }
            public string highest { get; set; }
        }

        public class SubCategory2
        {
            public List<Statistic2> statistics { get; set; }
        }

        public class SubCategory
        {
            public List<SubCategory2> subCategories { get; set; }
        }

        public class Statistics
        {
            public List<SubCategory> subCategories { get; set; }
        }

        public class RootObjectStatistics
        {           
            public Statistics statistics { get; set; }
        }
        #endregion
        #region Rootobjects Achievements
        public class Achievements
        {
            public List<int> achievementsCompleted { get; set; }
            public List<object> achievementsCompletedTimestamp { get; set; }
            public List<int> criteria { get; set; }
            public List<object> criteriaQuantity { get; set; }
        }

        public class RootObjectAchievements
        {            
            public Achievements achievements { get; set; }
        }
        #endregion
        #region Rootobjects Stats
        public class Stats
        {
            public int health { get; set; }
            public string powerType { get; set; }
            public int power { get; set; }
            public int str { get; set; }
            public int agi { get; set; }
            public int @int { get; set; }
            public int sta { get; set; }
            public double speedRating { get; set; }
            public double speedRatingBonus { get; set; }
            public double crit { get; set; }
            public int critRating { get; set; }
            public double haste { get; set; }
            public int hasteRating { get; set; }
            public double hasteRatingPercent { get; set; }
            public double mastery { get; set; }
            public int masteryRating { get; set; }
            public double leech { get; set; }
            public double leechRating { get; set; }
            public double leechRatingBonus { get; set; }
            public int versatility { get; set; }
            public double versatilityDamageDoneBonus { get; set; }
            public double versatilityHealingDoneBonus { get; set; }
            public double versatilityDamageTakenBonus { get; set; }
            public double avoidanceRating { get; set; }
            public double avoidanceRatingBonus { get; set; }
            public int spellPen { get; set; }
            public double spellCrit { get; set; }
            public int spellCritRating { get; set; }
            public double mana5 { get; set; }
            public double mana5Combat { get; set; }
            public int armor { get; set; }
            public double dodge { get; set; }
            public int dodgeRating { get; set; }
            public double parry { get; set; }
            public int parryRating { get; set; }
            public double block { get; set; }
            public int blockRating { get; set; }
            public double mainHandDmgMin { get; set; }
            public double mainHandDmgMax { get; set; }
            public double mainHandSpeed { get; set; }
            public double mainHandDps { get; set; }
            public double offHandDmgMin { get; set; }
            public double offHandDmgMax { get; set; }
            public double offHandSpeed { get; set; }
            public double offHandDps { get; set; }
            public double rangedDmgMin { get; set; }
            public double rangedDmgMax { get; set; }
            public double rangedSpeed { get; set; }
            public double rangedDps { get; set; }
        }

        public class RootObjectStats
        {
            public long lastModified { get; set; }
            public string name { get; set; }
            public string realm { get; set; }
            public string battlegroup { get; set; }
            public int @class { get; set; }
            public int race { get; set; }
            public int gender { get; set; }
            public int level { get; set; }
            public int achievementPoints { get; set; }
            public string thumbnail { get; set; }
            public string calcClass { get; set; }
            public int faction { get; set; }
            public Stats stats { get; set; }
            public int totalHonorableKills { get; set; }
        }
        #endregion
        #region Rootobjects Talents
        public class Spec
        {
            public string name { get; set; }
            public string role { get; set; }
            public string backgroundImage { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
            public int order { get; set; }
        }

        public class Talent
        {
            public bool selected { get; set; }
            public List<object> talents { get; set; }
            public Spec spec { get; set; }
            public string calcTalent { get; set; }
            public string calcSpec { get; set; }
        }

        public class RootObjectTalents
        {
            public long lastModified { get; set; }
            public string name { get; set; }
            public string realm { get; set; }
            public string battlegroup { get; set; }
            public int @class { get; set; }
            public int race { get; set; }
            public int gender { get; set; }
            public int level { get; set; }
            public int achievementPoints { get; set; }
            public string thumbnail { get; set; }
            public string calcClass { get; set; }
            public int faction { get; set; }
            public List<Talent> talents { get; set; }
            public int totalHonorableKills { get; set; }
        }
        #endregion
        #region Rootobjects Mounts
        public class Collected
        {
            public int itemId { get; set; }
        }

        public class Mounts
        {            
            public List<Collected> collected { get; set; }
        }

        public class RootObjectMounts
        {            
            public Mounts mounts { get; set; }
        }
        #endregion
        #region Rootobjects Audit
        public class Slots
        {
            public int __invalid_name__2 { get; set; }
            public int __invalid_name__15 { get; set; }
            public int __invalid_name__4 { get; set; }
            public int __invalid_name__5 { get; set; }
            public int __invalid_name__6 { get; set; }
            public int __invalid_name__7 { get; set; }
            public int __invalid_name__8 { get; set; }
            public int __invalid_name__9 { get; set; }
        }

        public class UnenchantedItems
        {
            public int __invalid_name__2 { get; set; }
            public int __invalid_name__15 { get; set; }
            public int __invalid_name__4 { get; set; }
            public int __invalid_name__6 { get; set; }
            public int __invalid_name__7 { get; set; }
            public int __invalid_name__8 { get; set; }
            public int __invalid_name__9 { get; set; }
        }

        public class ItemsWithEmptySockets
        {
            public int __invalid_name__8 { get; set; }
        }

        public class InappropriateArmorType
        {
        }

        public class LowLevelItems
        {
        }

        public class MissingExtraSockets
        {
            public int __invalid_name__5 { get; set; }
        }

        public class Spell
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
            public string castTime { get; set; }
        }

        public class ItemSpell
        {
            public int spellId { get; set; }
            public Spell spell { get; set; }
            public int nCharges { get; set; }
            public bool consumable { get; set; }
            public int categoryId { get; set; }
            public string trigger { get; set; }
        }

        public class ItemSource
        {
            public int sourceId { get; set; }
            public string sourceType { get; set; }
        }

        public class BonusSummary
        {
            public List<object> defaultBonusLists { get; set; }
            public List<object> chanceBonusLists { get; set; }
            public List<object> bonusChances { get; set; }
        }

        public class RecommendedBeltBuckle
        {
            public int id { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int stackable { get; set; }
            public int itemBind { get; set; }
            public List<object> bonusStats { get; set; }
            public List<ItemSpell> itemSpells { get; set; }
            public int buyPrice { get; set; }
            public int itemClass { get; set; }
            public int itemSubClass { get; set; }
            public int containerSlots { get; set; }
            public int inventoryType { get; set; }
            public bool equippable { get; set; }
            public int itemLevel { get; set; }
            public int maxCount { get; set; }
            public int maxDurability { get; set; }
            public int minFactionId { get; set; }
            public int minReputation { get; set; }
            public int quality { get; set; }
            public int sellPrice { get; set; }
            public int requiredSkill { get; set; }
            public int requiredLevel { get; set; }
            public int requiredSkillRank { get; set; }
            public ItemSource itemSource { get; set; }
            public int baseArmor { get; set; }
            public bool hasSockets { get; set; }
            public bool isAuctionable { get; set; }
            public int armor { get; set; }
            public int displayInfoId { get; set; }
            public string nameDescription { get; set; }
            public string nameDescriptionColor { get; set; }
            public bool upgradable { get; set; }
            public bool heroicTooltip { get; set; }
            public string context { get; set; }
            public List<object> bonusLists { get; set; }
            public List<string> availableContexts { get; set; }
            public BonusSummary bonusSummary { get; set; }
            public int artifactId { get; set; }
        }

        public class MissingBlacksmithSockets
        {
        }

        public class MissingEnchanterEnchants
        {
        }

        public class MissingEngineerEnchants
        {
        }

        public class MissingScribeEnchants
        {
        }

        public class MissingLeatherworkerEnchants
        {
        }

        public class Audit
        {
            public int numberOfIssues { get; set; }
            public Slots slots { get; set; }
            public int emptyGlyphSlots { get; set; }
            public int unspentTalentPoints { get; set; }
            public bool noSpec { get; set; }
            public UnenchantedItems unenchantedItems { get; set; }
            public int emptySockets { get; set; }
            public ItemsWithEmptySockets itemsWithEmptySockets { get; set; }
            public int appropriateArmorType { get; set; }
            public InappropriateArmorType inappropriateArmorType { get; set; }
            public LowLevelItems lowLevelItems { get; set; }
            public int lowLevelThreshold { get; set; }
            public MissingExtraSockets missingExtraSockets { get; set; }
            public RecommendedBeltBuckle recommendedBeltBuckle { get; set; }
            public MissingBlacksmithSockets missingBlacksmithSockets { get; set; }
            public MissingEnchanterEnchants missingEnchanterEnchants { get; set; }
            public MissingEngineerEnchants missingEngineerEnchants { get; set; }
            public MissingScribeEnchants missingScribeEnchants { get; set; }
            public int nMissingJewelcrafterGems { get; set; }
            public MissingLeatherworkerEnchants missingLeatherworkerEnchants { get; set; }
        }

        public class RootObjectAudit
        {
            public long lastModified { get; set; }
            public string name { get; set; }
            public string realm { get; set; }
            public string battlegroup { get; set; }
            public int @class { get; set; }
            public int race { get; set; }
            public int gender { get; set; }
            public int level { get; set; }
            public int achievementPoints { get; set; }
            public string thumbnail { get; set; }
            public string calcClass { get; set; }
            public int faction { get; set; }
            public Audit audit { get; set; }
            public int totalHonorableKills { get; set; }
        }
        #endregion
        #region Rootobjects Items

        public class TooltipParams
        {
            public int transmogItem { get; set; }
            public int timewalkerLevel { get; set; }
        }

        public class Stat
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }

        public class Appearance
        {
            public int itemId { get; set; }
            public int itemAppearanceModId { get; set; }
        }

        public class Head
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int quality { get; set; }
            public int itemLevel { get; set; }
            public TooltipParams tooltipParams { get; set; }
            public List<Stat> stats { get; set; }
            public int armor { get; set; }
            public string context { get; set; }
            public List<int> bonusLists { get; set; }
            public int artifactId { get; set; }
            public int displayInfoId { get; set; }
            public int artifactAppearanceId { get; set; }
            public List<object> artifactTraits { get; set; }
            public List<object> relics { get; set; }
            public Appearance appearance { get; set; }
        }

        public class TooltipParams2
        {
            public int gem0 { get; set; }
            public int enchant { get; set; }
            public int timewalkerLevel { get; set; }
        }

        public class Stat2
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }

        public class Appearance2
        {
            public int enchantDisplayInfoId { get; set; }
        }

        public class Neck
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int quality { get; set; }
            public int itemLevel { get; set; }
            public TooltipParams2 tooltipParams { get; set; }
            public List<Stat2> stats { get; set; }
            public int armor { get; set; }
            public string context { get; set; }
            public List<int> bonusLists { get; set; }
            public int artifactId { get; set; }
            public int displayInfoId { get; set; }
            public int artifactAppearanceId { get; set; }
            public List<object> artifactTraits { get; set; }
            public List<object> relics { get; set; }
            public Appearance2 appearance { get; set; }
        }

        public class TooltipParams3
        {
            public List<int> set { get; set; }
            public int transmogItem { get; set; }
            public int timewalkerLevel { get; set; }
        }

        public class Stat3
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }

        public class Appearance3
        {
            public int itemId { get; set; }
            public int itemAppearanceModId { get; set; }
        }

        public class Shoulder
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int quality { get; set; }
            public int itemLevel { get; set; }
            public TooltipParams3 tooltipParams { get; set; }
            public List<Stat3> stats { get; set; }
            public int armor { get; set; }
            public string context { get; set; }
            public List<int> bonusLists { get; set; }
            public int artifactId { get; set; }
            public int displayInfoId { get; set; }
            public int artifactAppearanceId { get; set; }
            public List<object> artifactTraits { get; set; }
            public List<object> relics { get; set; }
            public Appearance3 appearance { get; set; }
        }

        public class TooltipParams4
        {
            public int enchant { get; set; }
            public int tinker { get; set; }
            public int transmogItem { get; set; }
            public int timewalkerLevel { get; set; }
        }

        public class Stat4
        {
            public int stat { get; set; }
            public int amount { get; set; }
        }

        public class Appearance4
        {
            public int itemId { get; set; }
            public int enchantDisplayInfoId { get; set; }
            public int itemAppearanceModId { get; set; }
        }

        public class Back
        {
            public int id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int quality { get; set; }
            public int itemLevel { get; set; }
            public TooltipParams4 tooltipParams { get; set; }
            public List<Stat4> stats { get; set; }
            public int armor { get; set; }
            public string context { get; set; }
            public List<int> bonusLists { get; set; }
            public int artifactId { get; set; }
            public int displayInfoId { get; set; }
            public int artifactAppearanceId { get; set; }
            public List<object> artifactTraits { get; set; }
            public List<object> relics { get; set; }
            public Appearance4 appearance { get; set; }
        }

        public class Item
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public int quality { get; set; }
            public int itemLevel { get; set; }
            public List<ArtifactTrait> artifactTraits { get; set; }
            public List<Relic> relics { get; set; }
        }

        public class ArtifactTrait
        {
            public int id { get; set; }
            public int rank { get; set; }
        }

        public class Relic
        {
            public int socket { get; set; }
            public int itemId { get; set; }
            public int context { get; set; }
            public List<int> bonusLists { get; set; }
        }

        

        public class MainHand
        {            
            public List<ArtifactTrait> artifactTraits { get; set; }
            public List<Relic> relics { get; set; }
        }        

        public class OffHand
        {            
            public List<ArtifactTrait> artifactTraits { get; set; }
            public List<Relic> relics { get; set; }
        }

        public class Items
        {
            public int averageItemLevel { get; set; }
            public int averageItemLevelEquipped { get; set; }            
            public Item mainHand { get; set; }
            public Item offHand { get; set; }
        }

        public class RootObjectItems
        {
            public long lastModified { get; set; }
            public Items items { get; set; }
        }


        #endregion


        public RootObjectStatistics ConvertJsonStatistics(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectStatistics>(data);
        }
        public RootObjectAchievements ConvertJsonAchievements(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectAchievements>(data);
        }
        public RootObjectStats ConvertJsonStats(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectStats>(data);
        }
        public RootObjectTalents ConvertJsonTalents(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectTalents>(data);
        }
        public RootObjectMounts ConvertJsonMounts(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectMounts>(data);
        }
        public RootObjectItems ConvertJsonItems(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectItems>(data);
        }
        public RootObjectAudit ConvertJsonAudit(string data)
        {
            return JsonConvert.DeserializeObject<RootObjectAudit>(data);
        }
    }
}
