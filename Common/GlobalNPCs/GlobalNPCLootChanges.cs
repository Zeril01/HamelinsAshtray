namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class GlobalNPCLootChanges : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) =>
            npcLoot.Add(new Terraria.GameContent.ItemDropRules.ItemDropWithConditionRule(ModContent.ItemType<Content.Items.Yoyos.Ignition>(), 250/* 0.4% */, 1, 1, new ModConditions.ModYoyosIgnition()));
    }
}
