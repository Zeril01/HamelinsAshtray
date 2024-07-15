namespace HamelinsAshtray.Content.Projectiles
{
    public class Ignition : ModProjectile
    {
        public override void SetStaticDefaults() => ProjectileUtils.StaticDefaultsForYoyo(Type, 6f, 184f, 11f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI()
        {
            if (Main.rand.NextBool(9))
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IceRod, 0f, 0f, 100);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Frostburn, 90);
        }
    }
}
