using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace HamelinsAshtray.Content.Items
{
    public class HamelinsAshtrayGlowmask : ModPlayer
    {
        internal static readonly System.Collections.Generic.Dictionary<int, Texture2D> ItemGlowMask = [];
        internal new static void Unload() => ItemGlowMask.Clear();

        public static void AddGlowMask(int itemType, string texturePath) => ItemGlowMask[itemType] = ModContent.Request<Texture2D>(texturePath, ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
    }

    public class HamelinsAshtrayGlowMaskItemLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.ArmOverItem);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.drawPlayer.HeldItem.type >= ItemID.Count && HamelinsAshtrayGlowmask.ItemGlowMask.TryGetValue(drawInfo.drawPlayer.HeldItem.type, out Texture2D textureItem) && (drawInfo.drawPlayer.itemTime > 0 || drawInfo.drawPlayer.HeldItem.useStyle != ItemUseStyleID.None)) ItemGlowmaskUtils.DrawItemGlowMask(textureItem, drawInfo);
        }
    }
}
