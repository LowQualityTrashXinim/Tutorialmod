using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.CloneProjectile
{
	public class CursedArrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("CursedArrow");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.CursedArrow);
			AIType = ProjectileID.CursedArrow;
			Projectile.noDropItem = true;
			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.ranged = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 180);
		}
	}
}