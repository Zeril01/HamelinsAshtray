namespace HamelinsAshtray.Content.Projectiles.Yoyos
{
    public static class YoyoUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projType"></param>
        /// <param name="lifeTimeInSec">Vanilla values range from 3f (Wood) to 16f (Chik), and defaults to -1f.</param>
        /// <param name="maxRange">Vanilla values range from 130f (Wood) to 400f (Terrarian), and defaults to 200f.</param>
        /// <param name="topSpeed">Vanilla values range from 9f (Wood) to 17.5f (Terrarian), and defaults to 10f.</param>
        public static void StaticDefaultsForYoyo(int projType, float lifeTimeInSec, float maxRange, float topSpeed)
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projType] = lifeTimeInSec;
            ProjectileID.Sets.YoyosMaximumRange[projType] = maxRange;
            ProjectileID.Sets.YoyosTopSpeed[projType] = topSpeed;
        }

        public static void SpawnDusts(Microsoft.Xna.Framework.Vector2 position, int width, int height, int type)
        {
            if (Main.rand.NextBool(6))
            {
                int dust = Dust.NewDust(position, width, height, type);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
