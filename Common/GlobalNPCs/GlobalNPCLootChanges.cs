using HamelinsAshtray.Content.Items.Yoyos;
using Terraria.GameContent.ItemDropRules;

namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class GlobalNPCLootChanges : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            void AddYoyo(int type, IItemDropRuleCondition condition) => npcLoot.Add(new ItemDropWithConditionRule(type, 200/* 0.5% */, 1, 1, condition));
            
            AddYoyo(ModContent.ItemType<Corruption>(), new ModConditions.ModYoyosCorruption());
            AddYoyo(ModContent.ItemType<Elimination>(), new ModConditions.ModYoyosElimination());
            AddYoyo(ModContent.ItemType<Abduction>(), new ModConditions.ModYoyosAbduction());
        }
    }
}
