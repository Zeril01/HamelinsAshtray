namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Abduction : ModProjectile
    {
        private bool notWet = true;

        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type, 5f, 160f, 10.75f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI()
        {
            if (notWet)
            {
                if (Projectile.wet) notWet = false;
                YoyoUtils.SpawnDusts(Projectile.position, Projectile.width, Projectile.height, DustID.MushroomTorch);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (notWet) YoyoUtils.ApplyDebuffWithChance(target, ModContent.BuffType<Buffs.GlowingMushroomFireDebuff>());
        }
    }
}
