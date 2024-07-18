using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Content.Items.Yoyos
{
    public class Corruption : ModItem
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type, 5);
        
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Rally);
            Item.shoot = ModContent.ProjectileType<Projectiles.Yoyos.Corruption>();
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.Blue1, Item.sellPrice(silver: 75));
            Item.SetWeaponValues(15, 4f, 2);
        }

        public override void PostDrawInWorld(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(Item.position, new Vector3(0.75f / 2, 0.85f / 2, 1.4f / 2));
            YoyoUtils.SpawnDusts(Item.position, Item.width, Item.height, DustID.IceTorch);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) => YoyoTooltipUtils.AddEmptyTooltipForLogo(tooltips);

        public override void PostDrawTooltip(System.Collections.ObjectModel.ReadOnlyCollection<DrawableTooltipLine> lines) => YoyoTooltipUtils.PostDrawLogo(lines);
    }
}
