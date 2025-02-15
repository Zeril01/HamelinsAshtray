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
                case ItemID.JungleYoyo:
                case ItemID.Yelets:
                case ItemID.CrystalBullet:
                case ItemID.CursedBullet:
                case ItemID.IchorBullet:
                case ItemID.WormholePotion:
                case ItemID.ManaCrystal:
                    item.StatsModifiedBy.Add(Mod);
                    break;

                case ItemID.FlintlockPistol:
                    item.StatsModifiedBy.Add(Mod);
                    item.value = Item.sellPrice(silver: 6);
                    break;

                case ItemID.TungstenBullet:
                    item.StatsModifiedBy.Add(Mod);
                    item.shoot = ModContent.ProjectileType<Content.Projectiles.TungstenBullet>();
                    break;

                case ItemID.IceRod:
                    item.StatsModifiedBy.Add(Mod);
                    item.useStyle = ItemUseStyleID.Shoot;
                    break;
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
            void ShowWhilePressingShift(string text)
            {
                if (Main.keyState.PressingShift()) tooltips.Insert(VariousUtils.TooltipUtils.FindIndexByTooltipName(tooltips, "ModifiedByMods") + 1,
                    new(Mod, "ModifiedByHamelinsAshtray", text) { OverrideColor = new Microsoft.Xna.Framework.Color(255, 190, 152) }); // PANTONE - Peach Fuzz
            }

            string inflict = "Inflicts target with";
            switch (item.type)
            {
                case ItemID.IceBlade:
                    ShowWhilePressingShift($"{inflict} Frostburn");
                    break;

                case ItemID.JungleYoyo:
                case ItemID.Yelets:
                    ShowWhilePressingShift($"{inflict} Poisoned");
                    break;

                case ItemID.FlintlockPistol:
                    ShowWhilePressingShift("Item was resprite\nAt first crafting, bullets are given");
                    break;

                case ItemID.TungstenBullet:
                case ItemID.CrystalBullet:
                case ItemID.CursedBullet:
                case ItemID.IchorBullet:
                    ShowWhilePressingShift("Projectile was resprite");
                    break;

                case ItemID.IceRod:
                    ShowWhilePressingShift($"Use style was changed\n{inflict} Frostbite");
                    break;

                case ItemID.WormholePotion:
                    ShowWhilePressingShift("Always available from Merchant");
                    break;

                case ItemID.ManaCrystal:
                    ShowWhilePressingShift("Can be found Underground");
                    break;
            }
        }
    }
}
