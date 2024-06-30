namespace HamelinsAshtray.Common.GlobalProjectiles
{
    public class IchorBulletGlobalProjectiles : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.type == ProjectileID.IchorBullet;

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.IchorTorch);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2.5f;
                Main.dust[dust].scale *= 1.5f;
            }
        }
    }
}
