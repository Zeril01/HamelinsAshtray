namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class NPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant)
            {
                if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && shop.TryGetEntry(ItemID.WormholePotion, out NPCShop.Entry entry)) entry.Disable();
                shop.InsertBefore(ItemID.WoodenArrow, ItemID.WormholePotion, Condition.Multiplayer);
            }

            if (shop.NpcType == NPCID.ArmsDealer) shop.GetEntry(ItemID.FlintlockPistol).Disable();
        }
    }
}
