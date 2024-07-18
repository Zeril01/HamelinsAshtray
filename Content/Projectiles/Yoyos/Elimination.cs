namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Elimination : ModProjectile
    {
        private bool notWet = true;

        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsYoyo(Type, 6f, 184f, 12f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI()
        {
            if (notWet)
            {
                if (Projectile.wet) notWet = false;
                YoyoUtils.SpawnDusts(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (notWet) YoyoUtils.ApplyDebuffWithChance(target, ModContent.BuffType<Buffs.SapphireFireDebuff>());
        }
    }
}
