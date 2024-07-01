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

        public override bool PreAI()
        {
            if (!Main.dedServ && Projectile.timeLeft < 597 && Main.rand.NextBool(6))
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, DustID.SilverFlame, Projectile.velocity * 0f, 100, new Color(192, 224, 197), 1.2f);
                dust.noGravity = true;
            }
            return true;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
