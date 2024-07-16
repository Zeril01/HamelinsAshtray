using Terraria.GameContent.ItemDropRules;

namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class ModConditions
    {
        public class ModYoyosCorruption : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info)
            {
                if (!Main.hardMode && info.npc.HasPlayerTarget && info.player.ZoneSnow && info.npc.lifeMax > 5 && !info.npc.friendly && info.npc.value > 0f)
                    return !info.IsInSimulation;
                return false;
            }

            public bool CanShowItemDropInUI() => false;

            public string GetConditionDescription() => "Drops in Snow biome before Hardmode";
        }

        public class ModYoyosElimination : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info)
            {
                if (!Main.hardMode && info.npc.HasPlayerTarget && info.player.ZoneDesert && info.npc.lifeMax > 5 && !info.npc.friendly && info.npc.value > 0f)
                    return !info.IsInSimulation;
                return false;
            }

            public bool CanShowItemDropInUI() => false;

            public string GetConditionDescription() => "Drops in Desert biome before Hardmode";
        }
    }
}
