using HamelinsAshtray.Content.Projectiles;

namespace HamelinsAshtray.Utilities
{
    public static class HamelinsAshtrayUtils
    {
        public static HamelinsAshtrayPlayer HamelinsAshtray(this Player player) => player.GetModPlayer<HamelinsAshtrayPlayer>();
        public static HamelinsAshtrayGlobalNPC HamelinsAshtray(this NPC npc) => npc.GetGlobalNPC<HamelinsAshtrayGlobalNPC>();
        public static HamelinsAshtrayGlobalProjectile HamelinsAshtray(this Projectile proj) => proj.GetGlobalProjectile<HamelinsAshtrayGlobalProjectile>();

        public static void ShowTooltipWhileShiftIsClamped(System.Collections.Generic.List<TooltipLine> tooltips, string text)
        {
            var tooltip = new TooltipLine(ModLoader.GetMod("HamelinsAshtray"), "ModifiedByHamelinsAshtray", text)
            {
                OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) // PANTONE - Peach Fuzz
            };

            if (Main.keyState.PressingShift())
            {
                for (int i = tooltips.Count - 1; i >= tooltips.Count / 2; i--)
                {
                    if (tooltips[i].Mod == "Terraria" && tooltips[i].Name == "ModifiedByMods") tooltips.Insert(i + 1, tooltip);
                }
            }
        }
    }
}
