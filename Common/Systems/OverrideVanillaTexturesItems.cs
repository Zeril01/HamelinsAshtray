using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace HamelinsAshtray.Common.Systems
{
    public class OverrideVanillaTexturesItems : ModSystem
    {
        private ReLogic.Content.Asset<Texture2D> flintlockPistolTexture, crystalBulletTexture;

        public override void PostSetupContent()
        {
            flintlockPistolTexture = TextureAssets.Item[ItemID.FlintlockPistol];
            crystalBulletTexture = TextureAssets.Item[ItemID.CrystalBullet];

            TextureAssets.Item[ItemID.FlintlockPistol] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Items/FlintlockPistol");
            TextureAssets.Item[ItemID.CrystalBullet] = ModContent.Request<Texture2D>(HamelinsAshtray.AssetPath + "Items/CrystalBullet");
        }

        public override void Unload()
        {
            TextureAssets.Item[ItemID.FlintlockPistol] = flintlockPistolTexture;
            TextureAssets.Item[ItemID.CrystalBullet] = crystalBulletTexture;
        }
    }
}
