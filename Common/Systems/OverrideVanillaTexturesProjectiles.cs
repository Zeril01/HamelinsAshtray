using Terraria.GameContent;

namespace HamelinsAshtray.Common.Systems
{
    public class OverrideVanillaTexturesProjectiles : ModSystem
    {
        public override void PostSetupContent()
        {
            static void LoadModTexture(int projectileID, string textureName)
            {
                _ = TextureAssets.Projectile[projectileID];
                TextureAssets.Projectile[projectileID] = ModContent.Request<Microsoft.Xna.Framework.Graphics.Texture2D>(HamelinsAshtray.AssetPath + $"Projectiles/{textureName}");
            }

            LoadModTexture(ProjectileID.CrystalBullet, "CrystalBullet");
            LoadModTexture(ProjectileID.CrystalShard, "CrystalShard");
            LoadModTexture(ProjectileID.CursedBullet, "CursedBullet");
            LoadModTexture(ProjectileID.IchorBullet, "IchorBullet");
        }
    }
}
