using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Content.Items.Yoyos
{
    public class Abduction : ModItem
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type);

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Rally);
            Item.shoot = ModContent.ProjectileType<Projectiles.Yoyos.Abduction>();
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.Blue1, Item.sellPrice(silver: 62, copper: 50));
            Item.SetWeaponValues(15, 3.75f, 2);
        }

        public override void PostDrawInWorld(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!Item.wet) YoyoUtils.SpawnDusts(Item.position, Item.width, Item.height, DustID.MushroomTorch);
            Lighting.AddLight(Item.position, Vector3.Divide(new(0.3f, 0.78f, 1.2f), 2f));
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) => YoyoTooltipUtils.AddEmptyTooltipForLogo(tooltips);

        public override void PostDrawTooltip(System.Collections.ObjectModel.ReadOnlyCollection<DrawableTooltipLine> lines) => YoyoTooltipUtils.DrawLogo(lines);
    }
}
