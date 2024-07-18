namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class HamelinsAshtrayGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool glowingMushroomFireDebuff, sapphireFireDebuff, amberFireDebuff;

        public override void ResetEffects(NPC npc) => glowingMushroomFireDebuff = sapphireFireDebuff = amberFireDebuff = false;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            void ApplyDoT(int dmgPerSec, int displayableDmg, ref int dmg)
            {
                if (npc.lifeRegen > 0) npc.lifeRegen = 0;
                npc.lifeRegen -= dmgPerSec * 2;

                if (dmg < displayableDmg) dmg = displayableDmg;
            }

            if (glowingMushroomFireDebuff) ApplyDoT(2, 1, ref damage);

            if (sapphireFireDebuff) ApplyDoT(5, 2, ref damage);

            if (amberFireDebuff) ApplyDoT(8, 2, ref damage);

            if (npc.oiled && (glowingMushroomFireDebuff || sapphireFireDebuff || amberFireDebuff)) ApplyDoT(25, 10, ref damage);
        }

        public override void DrawEffects(NPC npc, ref Microsoft.Xna.Framework.Color drawColor)
        {
            void AddFireEffect(int type, int torchID)
            {
                if (Main.rand.Next(4) < 3)
                {
                    Dust dust = Dust.NewDustDirect(npc.position - new Microsoft.Xna.Framework.Vector2(2f, 2f), npc.width + 4, npc.height + 4, type, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 3.5f);
                    dust.noGravity = true;
                    dust.velocity *= 1.8f;
                    dust.velocity.Y -= 0.5f;

                    if (Main.rand.NextBool(4))
                    {
                        dust.noGravity = false;
                        dust.scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.Center, torchID);
            }

            if (sapphireFireDebuff) AddFireEffect(DustID.BlueTorch, TorchID.Blue);

            if (amberFireDebuff) AddFireEffect(DustID.OrangeTorch, TorchID.Orange);

            if (glowingMushroomFireDebuff) AddFireEffect(DustID.MushroomTorch, TorchID.Mushroom);
        }
    }
}
