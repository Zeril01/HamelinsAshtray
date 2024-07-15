namespace HamelinsAshtray.Content.Items.Yoyos
{
    public class Ignition : ModItem
    {
        public override void SetStaticDefaults() => ItemUtils.StaticDefaultsForYoyo(Type, 5);
        
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Rally);
            Item.shoot = ModContent.ProjectileType<Projectiles.Ignition>();
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.Blue1, Item.sellPrice(silver: 75));
            Item.SetWeaponValues(15, 4, 2);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) => YoyoTooltipUtils.AddEmptyTooltipForLogo(tooltips);

        public override void PostDrawTooltip(System.Collections.ObjectModel.ReadOnlyCollection<DrawableTooltipLine> lines) => YoyoTooltipUtils.PostDrawLogo(lines);
    }
}
