using HamelinsAshtray.Common.GlobalNPCs;
using HamelinsAshtray.Common.GlobalProjectiles;

namespace HamelinsAshtray.VariousUtils
{
    public static class GeneralExtensionUtils
    {
        public static HamelinsAshtrayGlobalNPC HamelinsAshtray(this NPC npc) => npc.GetGlobalNPC<HamelinsAshtrayGlobalNPC>();
        public static HamelinsAshtrayGlobalProjectile HamelinsAshtray(this Projectile proj) => proj.GetGlobalProjectile<HamelinsAshtrayGlobalProjectile>();
    }
}
