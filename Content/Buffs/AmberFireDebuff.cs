using HamelinsAshtray.Utilities;
using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Content.Buffs
{
    public class AmberFireDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = Main.pvpBuff[Type] = Main.buffNoSave[Type] = BuffID.Sets.LongerExpertDebuff[Type] = true;
            BuffID.Sets.GrantImmunityWith[Type].Add(BuffID.OnFire);
        }

        public override void Update(Player player, ref int buffIndex) => player.HamelinsAshtray().amberFireDebuff = true;

        internal static void DrawEffects(Terraria.DataStructures.PlayerDrawSet drawInfo)
        {
            if (Main.rand.NextBool(4))
            {
                Dust dust = Dust.NewDustDirect(drawInfo.Position - new Vector2(2f, 2f), drawInfo.drawPlayer.width + 4, drawInfo.drawPlayer.height + 4, DustID.OrangeTorch, drawInfo.drawPlayer.velocity.X * 0.4f, drawInfo.drawPlayer.velocity.Y * 0.4f, 100, default, 3f);
                dust.noGravity = true;
                dust.velocity *= 1.8f;
                dust.velocity.Y -= 0.5f;
                drawInfo.DustCache.Add(dust.dustIndex);
            }
        }

        public override void Update(NPC npc, ref int buffIndex) => npc.HamelinsAshtray().amberFireDebuff = true;

        internal static void DrawEffects(NPC npc)
        {
            if (Main.rand.Next(4) < 3)
            {
                Dust dust = Dust.NewDustDirect(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.OrangeTorch, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 3.5f);
                dust.noGravity = true;
                dust.velocity *= 1.8f;
                dust.velocity.Y -= 0.5f;

                if (Main.rand.NextBool(4))
                {
                    dust.noGravity = false;
                    dust.scale *= 0.5f;
                }
            }
            Lighting.AddLight(npc.Center, TorchID.Orange);
        }
    }
}
