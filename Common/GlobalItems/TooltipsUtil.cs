using System.Collections.Generic;

namespace HamelinsAshtray.Common.GlobalItems
{
    public static class TooltipsUtil
    {
        public static void ShowTooltipWhileShiftIsClamped(List<TooltipLine> tooltips, string text)
        {
            var tooltip = new TooltipLine(ModLoader.GetMod("HamelinsAshtray"), "ModifiedByHamelinsAshtray", text)
            {
                OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) // PANTONE - Peach Fuzz
            };
            if (Main.keyState.PressingShift()) tooltips.Insert(IndexOfTooltip(tooltips), tooltip);
        }

        static int IndexOfTooltip(List<TooltipLine> tooltips, string tooltipName = "ModifiedByMods")
        {
            for (int i = tooltips.Count - 1; i >= 0; i--)
            {
                if (tooltips[i].Name == tooltipName) return i + 1;
            }
            return tooltips.Count - 1;
        }
    }
}
