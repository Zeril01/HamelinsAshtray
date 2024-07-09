using Terraria.GameContent;

namespace HamelinsAshtray.Common.Systems
{
    public class OverrideVanillaTexturesItems : ModSystem
    {
        public override void PostSetupContent()
        {
            static void LoadModTexture(int itemID, string textureName)
            {
                _ = TextureAssets.Item[itemID];
                TextureAssets.Item[itemID] = ModContent.Request<Microsoft.Xna.Framework.Graphics.Texture2D>(HamelinsAshtray.AssetPath + $"Items/{textureName}");
            }

            LoadModTexture(ItemID.FlintlockPistol, "FlintlockPistol");
            LoadModTexture(ItemID.CrystalBullet, "CrystalBullet");
        }
    }
}
