using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.CloneProjectile
{
	public class FrostBurnArrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("FrostBurnArrow");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.FrostburnArrow);
			AIType = ProjectileID.FrostburnArrow;
			Projectile.noDropItem = true;
			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.ranged = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 180);
		}
	}
}