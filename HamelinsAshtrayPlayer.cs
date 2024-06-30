using HamelinsAshtray.Utilities;
using HamelinsAshtray.Content.Buffs;
using Terraria.DataStructures;

namespace HamelinsAshtray
{
    public class HamelinsAshtrayPlayer : ModPlayer
    {
        public bool canSpawnMusketBalls = true;

        public bool amberFireDebuff;

        public override void ResetEffects() => amberFireDebuff = false;

        public override void UpdateBadLifeRegen()
        {
            if (amberFireDebuff) //? Does not work in multiplayer, why?
            {
                if (Player.lifeRegen > 0) Player.lifeRegen = 0;

                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 36; //? return to 12
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            HamelinsAshtrayPlayer hap = Player.HamelinsAshtray();
            if (hap.amberFireDebuff && drawInfo.shadow == 0f) AmberFireDebuff.DrawEffects(drawInfo);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Content.Projectiles.HamelinsAshtrayGlobalProjectile hagl = proj.HamelinsAshtray();
            if (hagl.amberFireBullet) target.AddBuff(ModContent.BuffType<AmberFireDebuff>(), 90);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genDust, ref PlayerDeathReason damageSource)
        {
            if (amberFireDebuff) damageSource = PlayerDeathReason.ByCustomReason(" burned out, deceived by an amber smile."); //? Check
            return true;
        }
    }
}
