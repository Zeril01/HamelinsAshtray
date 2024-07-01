using HamelinsAshtray.Content.Projectiles;

namespace HamelinsAshtray.Utilities
{
    public static class GeneralExtensionUtils
    {
        public static HamelinsAshtrayPlayer HamelinsAshtray(this Player player) => player.GetModPlayer<HamelinsAshtrayPlayer>();
        public static HamelinsAshtrayGlobalNPC HamelinsAshtray(this NPC npc) => npc.GetGlobalNPC<HamelinsAshtrayGlobalNPC>();
        public static HamelinsAshtrayGlobalProjectile HamelinsAshtray(this Projectile proj) => proj.GetGlobalProjectile<HamelinsAshtrayGlobalProjectile>();
    }
}
