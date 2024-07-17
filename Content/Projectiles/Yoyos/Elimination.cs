namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public class Elimination : ModProjectile
    {
        public override void SetStaticDefaults() => YoyoUtils.StaticDefaultsForYoyo(Type, 6f, 184f, 12f);

        public override void SetDefaults() => Projectile.CloneDefaults(ProjectileID.Rally);

        public override void PostAI() => YoyoUtils.SpawnDusts(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3)) target.AddBuff(ModContent.BuffType<Buffs.SapphireFireDebuff>(), Main.rand.Next(60, 181));
        }
    }
}
