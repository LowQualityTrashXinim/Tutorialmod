using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon
{
	public class WoodenStickP2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spear");
		}

		public override void SetDefaults() {
			Projectile.width = 107;
			Projectile.height = 4;
			Projectile.penetrate = -1;
			Projectile.scale = 1.3f;
			Projectile.alpha = 0;

			Projectile.ownerHitCheck = true;
			Projectile.melee = true;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 20;
		}

		public override void AI() 
		{
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center;
			Projectile.position.X += 15f;
			Projectile.rotation += 20f;
		}
	}
}
