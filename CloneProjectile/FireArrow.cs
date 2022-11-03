using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.CloneProjectile
{
	public class FireArrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("FireArrow");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FireArrow);
			AIType = ProjectileID.FireArrow;
			Projectile.noDropItem = true;
			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.ranged = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 180);
        }
	}
}