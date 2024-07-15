namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class HamelinsAshtrayGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool amberFireDebuff;

        public override void ResetEffects(NPC npc) => amberFireDebuff = false;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            void ApplyDoT(int dmgPerSec, int displayableDmg, ref int dmg)
            {
                if (npc.lifeRegen > 0) npc.lifeRegen = 0;
                npc.lifeRegen -= dmgPerSec * 2;

                if (dmg < displayableDmg) dmg = displayableDmg;
            }

            if (amberFireDebuff) ApplyDoT(8, 2, ref damage);
            
            if (npc.oiled && amberFireDebuff) ApplyDoT(25, 10, ref damage);
        }

        public override void DrawEffects(NPC npc, ref Microsoft.Xna.Framework.Color drawColor)
        {
            if (amberFireDebuff) Content.Buffs.AmberFireDebuff.DrawEffects(npc);
        }
    }
}
