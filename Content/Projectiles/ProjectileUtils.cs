namespace HamelinsAshtray.Content.Projectiles
{
    public static class ProjectileUtils
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
    }
}
