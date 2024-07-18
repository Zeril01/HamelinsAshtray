using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Content.Items.Yoyos
{
    public class Elimination : ModItem
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type, 5);

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Rally);
            Item.shoot = ModContent.ProjectileType<Projectiles.Yoyos.Elimination>();
            Item.SetShopValues(Terraria.Enums.ItemRarityColor.Blue1, Item.sellPrice(gold: 1));
            Item.SetWeaponValues(16, 4.25f, 2);
        }

        public override void PostDrawInWorld(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!Item.wet) YoyoUtils.SpawnDusts(Item.position, Item.width, Item.height, DustID.BlueTorch);
            Lighting.AddLight(Item.position, Vector3.Divide(new(0f, 0.1f, 1.3f), 2f));
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) => YoyoTooltipUtils.AddEmptyTooltipForLogo(tooltips);

        public override void PostDrawTooltip(System.Collections.ObjectModel.ReadOnlyCollection<DrawableTooltipLine> lines) => YoyoTooltipUtils.DrawLogo(lines);
    }
}
