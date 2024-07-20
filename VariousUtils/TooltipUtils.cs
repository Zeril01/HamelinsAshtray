namespace HamelinsAshtray.VariousUtils
{
    public static class TooltipUtils
    {
        public static int FindIndexByTooltipName(System.Collections.Generic.List<TooltipLine> tooltips, string name)
        {
            int lastIndex = tooltips.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
            {
                if (tooltips[i].Mod == "Terraria" && tooltips[i].Name == name) return i;
            }
            return lastIndex;
        }
    }
}
