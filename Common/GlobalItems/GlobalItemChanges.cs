using System.Collections.Generic;

namespace HamelinsAshtray.Common.GlobalItems
{
    public class GlobalItemChanges : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type is ItemID.FlintlockPistol or ItemID.WormholePotion
            or ItemID.TungstenBullet or ItemID.CrystalBullet or ItemID.CursedBullet or ItemID.IchorBullet;

        public override void SetDefaults(Item item)
        {
            if (item.type is ItemID.FlintlockPistol or ItemID.WormholePotion or ItemID.TungstenBullet or ItemID.CrystalBullet
                or ItemID.CursedBullet or ItemID.IchorBullet) item.StatsModifiedBy.Add(Mod);
            
            if (item.type == ItemID.FlintlockPistol)
            {
                item.value = Item.sellPrice(silver: 5, copper: 50);
                item.rare = ItemRarityID.White;
            }

            if (item.type == ItemID.TungstenBullet)
            {
                item.shoot = ModContent.ProjectileType<Content.Projectiles.TungstenBullet>();
            }
        }

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

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            void ShowTooltipWhileShiftIsClamped(string text)
            {
                var tooltip = new TooltipLine(ModLoader.GetMod("HamelinsAshtray"), "ModifiedByHamelinsAshtray", text)
                { OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) }; // PANTONE - Peach Fuzz

                if (Main.keyState.PressingShift())
                {
                    for (int i = tooltips.Count - 1; i >= tooltips.Count / 2; i--)
                    {
                        if (tooltips[i].Mod == "Terraria" && tooltips[i].Name == "ModifiedByMods") tooltips.Insert(i + 1, tooltip);
                    }
                }
            }

            if (item.type == ItemID.FlintlockPistol) ShowTooltipWhileShiftIsClamped("Item was resprite\nAt first crafting, bullets are given");

            if (item.type == ItemID.WormholePotion) ShowTooltipWhileShiftIsClamped("Always available from Merchant");

            if (item.type is ItemID.TungstenBullet or ItemID.CrystalBullet or ItemID.CursedBullet or ItemID.IchorBullet)
                ShowTooltipWhileShiftIsClamped("Projectile was resprite");
        }
    }
}
