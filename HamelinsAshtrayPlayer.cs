using HamelinsAshtray.Utilities;

namespace HamelinsAshtray
{
    public class HamelinsAshtrayPlayer : ModPlayer
    {
        public bool canSpawnMusketBalls = true;

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer != Player.whoAmI) return;

            Content.Projectiles.HamelinsAshtrayGlobalProjectile hagl = proj.HamelinsAshtray();
            if (hagl.amberFireBullet) target.AddBuff(ModContent.BuffType<Content.Buffs.AmberFireDebuff>(), 90);
        }
    }
}
