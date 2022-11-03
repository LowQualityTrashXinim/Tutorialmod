using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.RBowClass
{
	public class BowOfLight : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoot out barrage of fire type arrow along with your arrow, have a chance to shoot out a phoenix \n Alt click to shoot a powerful Phoenix");
		}

		public override void SetDefaults() {
			Item.damage = 28;
			Item.crit = 15;
			Item.ranged = true;
			Item.width = 30;
			Item.height = 50;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 1;
			Item.shootSpeed = 40f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(Mod);
			recipe.AddIngredient(Mod, "PureSilver", 4);
			recipe.AddIngredient(ItemID.Pearlwood, 60);
			recipe.AddIngredient(ItemID.Topaz, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 45;
				Item.useAnimation = 45;
			}
			else
			{
				Item.useTime = 25;
				Item.useAnimation = 25;
			}
			return base.CanUseItem(player);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DD2PhoenixBowShot, damage*4, knockBack, player.whoAmI);
			}
			else
			{
				{
					for (int i = 0; i < 5; i++)
					{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
						perturbedSpeed.X += Main.rand.Next(-5, 5);
						perturbedSpeed.Y += Main.rand.Next(-5, 5);
						type = Main.rand.Next(new int[] { type, Mod.Find<ModProjectile>("FireArrow").Type, Mod.Find<ModProjectile>("FrostBurnArrow").Type, ProjectileID.ShadowFlameArrow, Mod.Find<ModProjectile>("CursedArrow").Type });
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					}
					int o = Main.rand.Next(1, 5);
					if (o == 2)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DD2PhoenixBowShot, damage, knockBack, player.whoAmI);
					}
				}
			}
			return false;
		}
	}
}

        // What if I wanted it to shoot like a shotgun?
        // Shotgun style: Multiple Projectiles, Random spread 
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}*/

        // What if I wanted an inaccurate gun? (Chain Gun)
        // Inaccurate Gun style: Single Projectile, Random spread 
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}*/

        // What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
        // Even Arc style: Multiple Projectile, Even Spread 
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}*/

        // Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
        /*public override Vector2? HoldoutOffset()
		{
			return new Vector2(10, 0);
		}*/

        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}*/

        // How can I get a "Clockwork Assault Rifle" effect?
        // 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
        /*	The following changes to SetDefaults()
		 	item.useAnimation = 12;
			item.useTime = 4;
			item.reuseDelay = 14;
		public override bool ConsumeAmmo(Player player)
		{
			// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.) 
			// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
			return !(player.itemAnimation < item.useAnimation - 2);
		}*/

        // How can I shoot 2 different projectiles at the same time?
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GrenadeI, damage, knockBack, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}*/

        // How can I choose between several projectiles randomly?
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ProjectileType<Projectiles.ExampleBullet>() });
			return true;
		}*/