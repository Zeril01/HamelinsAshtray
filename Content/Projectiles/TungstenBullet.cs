using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Content.Projectiles
{
    public class TungstenBullet : ModProjectile
    {
        public override string Texture => HamelinsAshtray.AssetPath + "Projectiles/TungstenBullet";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
