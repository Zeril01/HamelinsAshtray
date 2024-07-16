namespace HamelinsAshtray.Content.Items.Yoyos
{
    public static class YoyoUtils
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="gamepadExtraRange">Vanilla values: 4 (Wooden), 10 (Valor), 13 (Yelets), 18 (The Eye of Cthulhu), 21 (Terrarian).</param>
        public static void StaticDefaultsForYoyo(int itemType, int gamepadExtraRange = 4)
        {
            ItemID.Sets.Yoyo[itemType] = ItemID.Sets.GamepadSmartQuickReach[itemType] = true;
            ItemID.Sets.GamepadExtraRange[itemType] = gamepadExtraRange;
        }

        public static void SpawnDusts(Microsoft.Xna.Framework.Vector2 position, int width, int height, int type)
        {
            if (Main.rand.NextBool(50))
            {
                int dust = Dust.NewDust(position, width, height, type, 0f, 0f, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
