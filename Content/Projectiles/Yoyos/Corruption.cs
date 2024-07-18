namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Corruption : ModProjectile
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type, 5.5f, 176f, 11.5f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI() => YoyoUtils.SpawnDusts(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) => YoyoUtils.ApplyDebuffWithChance(target, BuffID.Frostburn);
    }
}
