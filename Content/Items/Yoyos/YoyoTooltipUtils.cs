using Microsoft.Xna.Framework.Graphics;

namespace HamelinsAshtray.Content.Items.Yoyos
{
    public static class YoyoTooltipUtils
    {
        public static void AddEmptyTooltipForLogo(System.Collections.Generic.List<TooltipLine> tooltips) =>
            tooltips.Insert(VariousUtils.TooltipUtils.FindIndexByTooltipName(tooltips, "Knockback"), new(ModLoader.GetMod("HamelinsAshtray"), "EmptyForLogo", "\u2800"));

        public static void PostDrawLogo(System.Collections.ObjectModel.ReadOnlyCollection<DrawableTooltipLine> lines)
        {
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].Mod == "HamelinsAshtray" && lines[i].Name == "EmptyForLogo")
                {
                    Main.spriteBatch.Draw(ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "UnprldLogo").Value,
                        new(lines[i].X - 1, lines[i].Y - 1), null,
                        new(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor),
                        0f, default, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
