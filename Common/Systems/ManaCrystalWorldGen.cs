using Terraria.IO;
using Terraria.WorldBuilding;

namespace HamelinsAshtray.Common.Systems
{
    public class ManaCrystalWorldGen : ModSystem
    {
        public override void ModifyWorldGenTasks(System.Collections.Generic.List<GenPass> tasks, ref double totalWeight)
        {
            if (!ModDetector.wayfairIsEnabled)
            {
                int lifeCrystalsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Life Crystals"));
                if (lifeCrystalsIndex != -1) tasks.Insert(lifeCrystalsIndex + 1, new WorldGenManaCrystalsPass("Mana Crystals", 100f));
            }
        }
    }

    public class WorldGenManaCrystalsPass(string name, float loadWeight) : GenPass(name, loadWeight)
    {
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing mana crystals";
            if (WorldGen.getGoodWorldGen) Main.tileSolid[TileID.Obsidian] = false;
            
            double maxNumOfManaCrystals = Main.maxTilesX * Main.maxTilesY * 1E-05;
            if (WorldGen.tenthAnniversaryWorldGen) maxNumOfManaCrystals *= 1.2;
            if (Main.starGame) maxNumOfManaCrystals *= Main.starGameMath(0.2);

            for (int i = 0; i < (int)maxNumOfManaCrystals; i++)
            {
                progress.Set(i / (Main.maxTilesX * Main.maxTilesY * 1E-05));
                bool success = false;
                int attempts = 1;

                while (!success)
                {
                    int y = WorldGen.genRand.Next((int)(Main.worldSurface * 2.0 + Main.rockLayer) / 3, Main.maxTilesY - 300);
                    if (WorldGen.remixWorldGen) y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 400);
                    
                    if (AddManaCrystal(WorldGen.genRand.Next(Main.offLimitBorderTiles, Main.maxTilesX - Main.offLimitBorderTiles), y)) success = true;
                    else
                    {
                        attempts++;
                        if (attempts >= 5000) success = true;
                    }
                }
            }

            static bool AddManaCrystal(int x, int y)
            {
                for (int i = y; i < Main.maxTilesY; i++)
                {
                    if (Main.tile[x, i].HasTile && Main.tileSolid[Main.tile[x, i].TileType])
                    {
                        int y0 = i - 1;
                        if ((Main.tile[x, y0 - 1].LiquidType is LiquidID.Lava or LiquidID.Shimmer) ||
                            Main.tile[x - 1, y0 - 1].LiquidType == LiquidID.Lava) return false;

                        if (!WorldGen.EmptyTileCheck(x - 1, x, y0 - 1, y0) || Main.wallDungeon[Main.tile[x, y0].WallType]) return false;

                        Tile tile0 = Main.tile[x - 1, y0 + 1];
                        Tile tile1 = Main.tile[x, y0 + 1];

                        if (!tile0.HasUnactuatedTile || !Main.tileSolid[tile0.TileType] ||
                            !tile1.HasUnactuatedTile || !Main.tileSolid[tile1.TileType]) return false;

                        static void BlockTypeNotZero(Tile tile)
                        {
                            if (tile.BlockType != 0)
                            {
                                tile.Slope = SlopeType.Solid;
                                tile.IsHalfBlock = false;
                            }
                        }

                        BlockTypeNotZero(tile0);
                        BlockTypeNotZero(tile1);

                        WorldGen.Place2x2(x, y0, TileID.ManaCrystal, 0);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
