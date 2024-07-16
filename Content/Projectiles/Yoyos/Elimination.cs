namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Elimination : ModProjectile
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsForYoyo(Type, 6f, 184f, 12f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);
    }
}
