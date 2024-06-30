using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace HamelinsAshtray.Common.Systems
{
    public class OverrideVanillaTexturesProjectiles : ModSystem
    {
        private ReLogic.Content.Asset<Texture2D> cursedBulletTexture, ichorBulletTexture, crystalBulletTexture, crystalShardTexture;

        public override void PostSetupContent()
        {
            cursedBulletTexture = TextureAssets.Projectile[ProjectileID.CursedBullet];
            ichorBulletTexture = TextureAssets.Projectile[ProjectileID.IchorBullet];
            crystalBulletTexture = TextureAssets.Projectile[ProjectileID.CrystalBullet];
            crystalShardTexture = TextureAssets.Projectile[ProjectileID.CrystalShard];

            TextureAssets.Projectile[ProjectileID.CursedBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CursedBullet");
            TextureAssets.Projectile[ProjectileID.IchorBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/IchorBullet");
            TextureAssets.Projectile[ProjectileID.CrystalBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CrystalBullet");
            TextureAssets.Projectile[ProjectileID.CrystalShard] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Projectiles/CrystalShard");
        }

        public override void Unload()
        {
            TextureAssets.Projectile[ProjectileID.CursedBullet] = cursedBulletTexture;
            TextureAssets.Projectile[ProjectileID.IchorBullet] = ichorBulletTexture;
            TextureAssets.Projectile[ProjectileID.CrystalBullet] = crystalBulletTexture;
            TextureAssets.Projectile[ProjectileID.CrystalShard] = crystalShardTexture;
        }
    }
}
