using HamelinsAshtray.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HamelinsAshtray.Content.Items
{
    public class AmberFlamingPistol : ModItem
    {
        public override string Texture => HamelinsAshtray.AssetPath + "Items/AmberFlamingPistol";

        public override void SetStaticDefaults() => HamelinsAshtrayGlowmask.AddGlowMask(Item.type, Texture + "Glow");
        
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FlintlockPistol);

            Item.StatsModifiedBy.Clear();
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile amberFireShot = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            Projectiles.HamelinsAshtrayGlobalProjectile hagl = amberFireShot.HamelinsAshtray();
            hagl.amberFireBullet = true;
            return false;
        }

        public override Vector2? HoldoutOffset() => new(6f, 2f);

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            GlowmaskUtils.DrawItemGlowMaskWorld(spriteBatch, Item, ModContent.Request<Texture2D>(Texture + "Glow").Value, rotation, scale);
            Lighting.AddLight(Item.Center, TorchID.Orange);
        }

        public override void AddRecipes() => CreateRecipe().
            AddIngredient(ItemID.FlintlockPistol).
            AddIngredient(ItemID.Amber, 6).
            AddIngredient(ItemID.Torch, 99).
            AddTile(TileID.Anvils).
            Register();
    }
}
