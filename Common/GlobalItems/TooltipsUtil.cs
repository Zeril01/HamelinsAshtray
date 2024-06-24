using System.Linq;

namespace HamelinsAshtray.Common.GlobalItems
{
    public static class TooltipsUtil
    {
        public static void AddTooltipOfChanges(System.Collections.Generic.List<TooltipLine> tooltips, string changes)
        {
            var tooltip = new TooltipLine(ModLoader.GetMod("HamelinsAshtray"), "ModifiedByMods", changes)
            {
                OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) // PANTONE - Peach Fuzz
            };

            if (Main.keyState.PressingShift())
            {
                tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Price")?.Hide();
                tooltips.Add(tooltip);
            }
        }
    }
}
