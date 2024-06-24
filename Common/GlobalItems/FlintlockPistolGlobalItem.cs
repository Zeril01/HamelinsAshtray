using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.GameContent;

namespace HamelinsAshtray.Common.GlobalItems
{
    public class FlintlockPistolGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.FlintlockPistol;

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.value = Item.sellPrice(silver: 4, copper: 50);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) =>
            TooltipsUtil.AddTooltipOfChanges(tooltips, "Item was resprite\nAt first crafting, bullets are given");

        public override void AddRecipes()
        {
            FlintlockPistolPlayer modPlayer = new();

            Recipe.Create(ItemID.FlintlockPistol)
                  .AddRecipeGroup(RecipeGroupID.IronBar, 8)
                  .AddRecipeGroup(RecipeGroupID.Wood, 3)
                  .AddTile(TileID.Anvils)

                  .AddOnCraftCallback((Recipe recipe, Item item, List<Item> consumedItems, Item destinationStack) =>
                  {
                      if (modPlayer.canSpawnMusketBalls)
                      {
                          Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.MusketBall, 50);
                          modPlayer.canSpawnMusketBalls = false;
                      }
                  })
                  .Register();
        }
    }

    public class FlintlockPistolPlayer : ModPlayer
    {
        public bool canSpawnMusketBalls = true;
    }

    public class NewFlintlockPistolTexture : ModSystem
    {
        private ReLogic.Content.Asset<Texture2D> flintlockPistolTexture;

        public override void PostSetupContent()
        {
            flintlockPistolTexture = TextureAssets.Item[ItemID.FlintlockPistol];
            TextureAssets.Item[ItemID.FlintlockPistol] = ModContent.Request<Texture2D>("HamelinsAshtray/Assets/Items/FlintlockPistol");
        }

        public override void Unload() => TextureAssets.Item[ItemID.FlintlockPistol] = flintlockPistolTexture;
    }
}
