namespace HamelinsAshtray.Common.GlobalItems
{
    public class TungstenBulletGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.TungstenBullet;

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.shoot = ModContent.ProjectileType<Content.Projectiles.TungstenBullet>();
        }

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) =>
            Utilities.HamelinsAshtrayUtils.ShowTooltipWhileShiftIsClamped(tooltips, "Projectile was resprite");
    }
}
