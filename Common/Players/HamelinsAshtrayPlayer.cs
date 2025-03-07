﻿using HamelinsAshtray.VariousUtils;

namespace HamelinsAshtray.Common.Players
{
    public class HamelinsAshtrayPlayer : ModPlayer
    {
        public bool canSpawnMusketBalls = true;

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer != Player.whoAmI) return;

            GlobalProjectiles.HamelinsAshtrayGlobalProjectile hagl = proj.HamelinsAshtray();
            if (hagl.amberFireBullet) target.AddBuff(ModContent.BuffType<Content.Buffs.AmberFireDebuff>(), 90);
        }
    }
}
