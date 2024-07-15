using Terraria.GameContent.ItemDropRules;

namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class ModConditions
    {
        public class ModYoyosIgnition : IItemDropRuleCondition, IProvideItemConditionDescription
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
    }
}
