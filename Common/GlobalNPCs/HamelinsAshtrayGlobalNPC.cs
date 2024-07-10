namespace HamelinsAshtray.Common.GlobalNPCs
{
    public class HamelinsAshtrayGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool amberFireDebuff;

        public override void ResetEffects(NPC npc) => amberFireDebuff = false;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (amberFireDebuff)
            {
                if (npc.lifeRegen > 0) npc.lifeRegen = 0;
                npc.lifeRegen -= 6 * 2;

                if (damage < 2) damage = 2;
            }

            if (amberFireDebuff && npc.oiled)
            {
                if (npc.lifeRegen > 0) npc.lifeRegen = 0;
                npc.lifeRegen -= 25 * 2;

                if (damage < 10) damage = 10;
            }
        }

        public override void DrawEffects(NPC npc, ref Microsoft.Xna.Framework.Color drawColor)
        {
            if (amberFireDebuff) Content.Buffs.AmberFireDebuff.DrawEffects(npc);
        }
    }
}
