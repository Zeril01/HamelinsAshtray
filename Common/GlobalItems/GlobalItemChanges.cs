using System.Collections.Generic;

namespace HamelinsAshtray.Common.GlobalItems
{
    public class GlobalItemChanges : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void SetStaticDefaults() => Item.staff[ItemID.IceRod] = true;
        
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.IceBlade:
                case ItemID.CrystalBullet:
                case ItemID.CursedBullet:
                case ItemID.IchorBullet:
                case ItemID.WormholePotion:
                    item.StatsModifiedBy.Add(Mod);
                    break;

                case ItemID.FlintlockPistol:
                    item.value = Item.sellPrice(silver: 6);
                    goto case ItemID.WormholePotion;

                case ItemID.TungstenBullet:
                    item.shoot = ModContent.ProjectileType<Content.Projectiles.TungstenBullet>();
                    goto case ItemID.WormholePotion;

                case ItemID.IceRod:
                    item.useStyle = ItemUseStyleID.Shoot;
                    goto case ItemID.WormholePotion;
            }
        }

        public override void AddRecipes()
        {
            Players.HamelinsAshtrayPlayer hap = new();

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
                if (Main.keyState.PressingShift()) tooltips.Insert(VariousUtils.TooltipUtils.FindIndexByTooltipName(tooltips, "ModifiedByMods"),
                    new(Mod, "ModifiedByHamelinsAshtray", text) { OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) }); // PANTONE - Peach Fuzz
            }

            switch (item.type)
            {
                case ItemID.IceBlade:
                    ShowTooltipWhileShiftIsClamped("Inflicts target with Frostburn");
                    break;

                case ItemID.FlintlockPistol:
                    ShowTooltipWhileShiftIsClamped("Item was resprite\nAt first crafting, bullets are given");
                    break;

                case ItemID.TungstenBullet:
                case ItemID.CrystalBullet:
                case ItemID.CursedBullet:
                case ItemID.IchorBullet:
                    ShowTooltipWhileShiftIsClamped("Projectile was resprite");
                    break;

                case ItemID.IceRod:
                    ShowTooltipWhileShiftIsClamped("Use style was changed\nInflicts target with Frostbite");
                    break;

                case ItemID.WormholePotion:
                    ShowTooltipWhileShiftIsClamped("Always available from Merchant");
                    break;
            }
        }
    }
}
