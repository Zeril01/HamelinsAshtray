using Microsoft.Xna.Framework;

namespace HamelinsAshtray.Common.GlobalItems
{
    public class TungstenBulletGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.TungstenBullet;

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);
            item.shoot = ModContent.ProjectileType<TungstenBullet>();
        }

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) =>
            TooltipsUtil.ShowTooltipWhileShiftIsClamped(tooltips, "Projectile was resprite");
    }

    public class TungstenBullet : ModProjectile
    {
        public override string Texture => HamelinsAshtray.AssetPath + "Projectiles/TungstenBullet";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
