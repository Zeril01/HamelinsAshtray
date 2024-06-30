namespace HamelinsAshtray.Content.Projectiles
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

                Dust dust = Dust.NewDustPerfect(projectile.Center, DustID.OrangeTorch, projectile.velocity * Main.rand.NextFloat(0.25f, 0.76f));
                dust.noGravity = true;
            }
        }
    }
}
