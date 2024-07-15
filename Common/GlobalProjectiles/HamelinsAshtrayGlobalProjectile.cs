namespace HamelinsAshtray.Common.GlobalProjectiles
{
    public class HamelinsAshtrayGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool amberFireBullet = false;

        public override void AI(Projectile projectile)
        {
            if (amberFireBullet && projectile.timeLeft < 597)
            {
                if (projectile.wet) amberFireBullet = false;

                Dust dust = Dust.NewDustPerfect(projectile.Center, DustID.OrangeTorch, projectile.velocity * Main.rand.NextFloat(0.25f, 0.76f), 100);
                dust.noGravity = true;
            }
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (amberFireBullet)
            {
                for (int i = 0; i < 8; i++) Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 0.8f);
            }
        }
    }
}
