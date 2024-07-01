using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace HamelinsAshtray.Common.Systems
{
    public class OverrideVanillaTexturesProjectiles : ModSystem
    {
        private ReLogic.Content.Asset<Texture2D> crystalBulletTexture, crystalShardTexture, cursedBulletTexture, ichorBulletTexture;

        public override void PostSetupContent()
        {
            crystalBulletTexture = TextureAssets.Projectile[ProjectileID.CrystalBullet];
            crystalShardTexture = TextureAssets.Projectile[ProjectileID.CrystalShard];
            cursedBulletTexture = TextureAssets.Projectile[ProjectileID.CursedBullet];
            ichorBulletTexture = TextureAssets.Projectile[ProjectileID.IchorBullet];

            TextureAssets.Projectile[ProjectileID.CrystalBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CrystalBullet");
            TextureAssets.Projectile[ProjectileID.CrystalShard] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CrystalShard");
            TextureAssets.Projectile[ProjectileID.CursedBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CursedBullet");
            TextureAssets.Projectile[ProjectileID.IchorBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/IchorBullet");
        }

        public override void Unload()
        {
            TextureAssets.Projectile[ProjectileID.CrystalBullet] = crystalBulletTexture;
            TextureAssets.Projectile[ProjectileID.CrystalShard] = crystalShardTexture;
            TextureAssets.Projectile[ProjectileID.CursedBullet] = cursedBulletTexture;
            TextureAssets.Projectile[ProjectileID.IchorBullet] = ichorBulletTexture;
        }
    }
}
