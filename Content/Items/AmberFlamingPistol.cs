using HamelinsAshtray.VariousUtils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HamelinsAshtray.Content.Items
{
    public class AmberFlamingPistol : ModItem
    {
        public override string Texture => HamelinsAshtray.AssetPath + "Items/AmberFlamingPistol";

        public override void SetStaticDefaults() => HamelinsAshtrayGlowmask.AddGlowmask(Item.type, Texture + "_Glow");
        
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlintlockPistol);

            Item.StatsModifiedBy.Clear();
            Item.value = Item.sellPrice(silver: 55);
            Item.crit += 2;
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile amberFireShot = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            Common.GlobalProjectiles.HamelinsAshtrayGlobalProjectile hagl = amberFireShot.HamelinsAshtray();
            hagl.amberFireBullet = true;
            return false;
        }

        public override Vector2? HoldoutOffset() => new(6f, 2f);

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) =>
            ItemGlowmaskUtils.DrawItemGlowmaskInWorld(Item, rotation, scale, ModContent.Request<Texture2D>(Texture + "_Glow").Value);

        public override void AddRecipes() => CreateRecipe().
            AddIngredient(ItemID.FlintlockPistol).
            AddIngredient(ItemID.Amber, 6).
            AddIngredient(ItemID.Torch, 99).
            AddTile(TileID.Anvils).
            Register();
    }
}
