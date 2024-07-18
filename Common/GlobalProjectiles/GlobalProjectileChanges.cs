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

        public override void PostAI(Projectile projectile)
        {
            if ((projectile.type == ProjectileID.JungleYoyo || projectile.type == ProjectileID.Yelets) && Main.rand.NextBool(6))
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Poisoned, 0f, 0f, 100);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            switch (projectile.type)
            {
                case ProjectileID.IceBolt:
                    if (!Systems.ModDetector.calamityIsEnabled) target.AddBuff(BuffID.Frostburn, 90);
                    break;

                case ProjectileID.JungleYoyo:
                    if (Main.rand.NextBool(3)) target.AddBuff(BuffID.Poisoned, Main.rand.Next(60, 181));
                    break;

                case ProjectileID.Yelets:
                    if (Main.rand.NextBool(2)) target.AddBuff(BuffID.Poisoned, Main.rand.Next(300, 901));
                    break;

                case ProjectileID.IceBlock:
                    target.AddBuff(BuffID.Frostburn2, 600);
                    break;
            }
        }
    }
}
