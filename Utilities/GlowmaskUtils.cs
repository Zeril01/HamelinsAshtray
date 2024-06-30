using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace HamelinsAshtray.Utilities
{
    public static class GlowmaskUtils
    {
        public static void DrawItemGlowMask(Texture2D texture, PlayerDrawSet info)
        {
            Item item = info.drawPlayer.HeldItem;
            if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == ItemUseStyleID.None) && (item.holdStyle <= 0 || info.drawPlayer.pulley)) || info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet)) return;

            Vector2 offset, origin;
            offset = origin = Vector2.Zero;
            float rotOffset = 0;

            if (item.useStyle == ItemUseStyleID.Shoot)
            {
                if (Item.staff[item.type])
                {
                    rotOffset = 0.785f * info.drawPlayer.direction;
                    if (info.drawPlayer.gravDir == -1f) rotOffset -= 1.57f * info.drawPlayer.direction;

                    origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);

                    int oldOriginX = -(int)origin.X;
                    ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
                    offset = new Vector2(origin.X + oldOriginX, 0);
                }
                else
                {
                    offset = new Vector2(10, texture.Height / 2);
                    ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);

                    origin = new Vector2((int)-offset.X, texture.Height / 2);
                    if (info.drawPlayer.direction == -1) origin.X = texture.Width + offset.X;

                    offset = new Vector2(0, offset.Y);
                }
            }
            else origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);

            info.DrawDataCache.Add(new DrawData(texture, new Vector2((int)(info.ItemLocation.X - Main.screenPosition.X + offset.X), (int)(info.ItemLocation.Y - Main.screenPosition.Y + offset.Y)), texture.Bounds, Color.White * ((255f - item.alpha) / 255f), info.drawPlayer.itemRotation + rotOffset, origin, item.scale, info.playerEffect, 0));
        }

        public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale) =>
            Main.spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width / 2, item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2)), new Rectangle(0, 0, texture.Width, texture.Height), Color.White * ((255f - item.alpha) / 255f), rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0f);
    }
}
