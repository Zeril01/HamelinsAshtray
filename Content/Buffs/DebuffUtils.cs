namespace HamelinsAshtray.Content.Buffs
{
    public static class DebuffUtils
    {
        public static void StaticDefaultsDebuff(int debuffType)
        {
            Main.debuff[debuffType] = Main.pvpBuff[debuffType] = Main.buffNoSave[debuffType] = BuffID.Sets.LongerExpertDebuff[debuffType] = true;
            BuffID.Sets.GrantImmunityWith[debuffType].Add(BuffID.OnFire);
        }
    }
}
