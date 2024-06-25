namespace HamelinsAshtray.Common.GlobalItems
{
    public class WormholePotionGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.WormholePotion;

        public override void SetDefaults(Item item) => item.StatsModifiedBy.Add(Mod);

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) =>
            TooltipsUtil.ShowTooltipWhileShiftIsClamped(tooltips, "Always available from Merchant");
    }
}
