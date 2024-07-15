namespace HamelinsAshtray.Common.GlobalProjectiles
{
    public class GlobalProjectileChanges : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            static void SpawnDusts(Projectile projectile, int type, float scale = 1.2f)
            {
                Dust dust = Dust.NewDustPerfect(projectile.Center, type, projectile.velocity * 0f, 100, default, scale);
                dust.noGravity = true;
            }

            if (projectile.timeLeft < 597)
            {
                if (projectile.type == ProjectileID.GoldenBullet && Main.rand.NextBool(8))
                {
                    SpawnDusts(projectile, DustID.GoldFlame);
                }

                if (projectile.type == ProjectileID.ExplosiveBullet && Main.rand.NextBool(10))
                {
                    SpawnDusts(projectile, DustID.Torch);
                    SpawnDusts(projectile, DustID.Smoke, 0.8f);
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.type == ProjectileID.IceBolt && !Systems.ModDetector.calamityIsEnabled) target.AddBuff(BuffID.Frostburn, 90);

            if (projectile.type == ProjectileID.IceBlock) target.AddBuff(BuffID.Frostburn2, 60 * 10);
        }
    }
}
