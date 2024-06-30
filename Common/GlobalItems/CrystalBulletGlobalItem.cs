﻿namespace HamelinsAshtray.Common.GlobalItems
{
    public class CrystalBulletGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.CrystalBullet;

        public override void SetDefaults(Item item) => item.StatsModifiedBy.Add(Mod);

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) =>
            Utilities.HamelinsAshtrayUtils.ShowTooltipWhileShiftIsClamped(tooltips, "Projectile was resprite");
    }
}
