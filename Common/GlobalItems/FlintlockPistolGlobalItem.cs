using System.Collections.Generic;

namespace HamelinsAshtray.Common.GlobalItems
{
    public class FlintlockPistolGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.FlintlockPistol;

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);

            item.value = Item.sellPrice(silver: 5, copper: 50);
            item.rare = ItemRarityID.White;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) =>
            Utilities.HamelinsAshtrayUtils.ShowTooltipWhileShiftIsClamped(tooltips, "Item was resprite\nAt first crafting, bullets are given");

        public override void AddRecipes()
        {
            HamelinsAshtrayPlayer hap = new();

            Recipe.Create(ItemID.FlintlockPistol)
                  .AddRecipeGroup(RecipeGroupID.IronBar, 10)
                  .AddRecipeGroup(RecipeGroupID.Wood, 3)
                  .AddTile(TileID.Anvils)

                  .AddOnCraftCallback((Recipe recipe, Item item, List<Item> consumedItems, Item destinationStack) =>
                  {
                      if (hap.canSpawnMusketBalls)
                      {
                          Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.MusketBall, 50);
                          hap.canSpawnMusketBalls = false;
                      }
                  })
                  .Register();
        }
    }
}
