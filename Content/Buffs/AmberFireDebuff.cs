using HamelinsAshtray.VariousUtils;

namespace HamelinsAshtray.Content.Buffs
{
    public class AmberFireDebuff : ModBuff
    {
        public override void SetStaticDefaults() => DebuffUtils.StaticDefaultsDebuff(Type);
        
        public override void Update(NPC npc, ref int buffIndex) => npc.HamelinsAshtray().amberFireDebuff = true;
    }
}
