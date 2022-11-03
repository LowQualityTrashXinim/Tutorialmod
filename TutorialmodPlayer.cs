using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod
{
	public class TutorialmodPlayer : ModPlayer
	{
		public bool MashedOfCopper;
		public bool TinPower;

		public override void ResetEffects()
		{
			MashedOfCopper = false;
			TinPower = false;
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockBack, bool crit)
		{
			int RandomChance = Main.rand.Next(4, 6);
			//Mashed of Copper Accessory
			Vector2 vectorFromPlayerToNPC = target.Center - Player.Center;
			Vector2 directionFromPlayerToNPC = vectorFromPlayerToNPC.SafeNormalize(Vector2.UnitX);
			float shootVelocity = 25;
			if (MashedOfCopper && RandomChance == 5)
			{
				Projectile.NewProjectile(Player.Center, directionFromPlayerToNPC * shootVelocity, Mod.Find<ModProjectile>("MoCShortSwordP").Type, 7, knockBack, Player.whoAmI);
			}
			// End of Mashed of Copper
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			int RandomChance = Main.rand.Next(4, 6);
			//Mashed of Copper Accessory
			Vector2 vectorFromPlayerToNPC = target.Center - Player.Center;
			Vector2 directionFromPlayerToNPC = vectorFromPlayerToNPC.SafeNormalize(Vector2.UnitX);
			float shootVelocity = 25;
			if (MashedOfCopper && RandomChance == 5)
			{
				Projectile.NewProjectile(Player.Center, directionFromPlayerToNPC * shootVelocity, Mod.Find<ModProjectile>("MoCShortSwordP").Type, 7, knockback, Player.whoAmI);
			}
			// End of Mashed of Copper
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			//Mashed of Copper Accessory
			float shootVelocity = 10f;
			if (MashedOfCopper)
			{
				for (int i = 0; i < 5; i++)
				{
					Vector2 speed = Main.rand.NextVector2Unit((float)MathHelper.Pi / -4, (float)MathHelper.Pi / -2);
					Projectile.NewProjectile(Player.Center, speed * shootVelocity, Mod.Find<ModProjectile>("MoCCopperOre").Type, 30, 2, Player.whoAmI);
				}
				// End of Mashed of Copper
			}
		}
		public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
		{
			//Mashed of Copper Accessory
			float shootVelocity = 10f;
			if (MashedOfCopper)
			{
				for (int i = 0; i < 5; i++)
				{
					Vector2 speed = Main.rand.NextVector2Unit((float)MathHelper.Pi / -4, (float)MathHelper.Pi / -2);
					Projectile.NewProjectile(Player.Center, speed * shootVelocity, Mod.Find<ModProjectile>("MoCCopperOre").Type, 30, 2, Player.whoAmI);
				}
			}
		}
			// End of Mashed of Copper        
	}
}