namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Abduction : ModProjectile
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsForYoyo(Type, 5f, 160f, 10.75f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI() => YoyoUtils.SpawnDusts(Projectile.position, Projectile.width, Projectile.height, DustID.MushroomTorch);
    }
}
