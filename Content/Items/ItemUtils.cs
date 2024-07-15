namespace HamelinsAshtray.Content.Items
{
    public static class ItemUtils
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
    }
}
