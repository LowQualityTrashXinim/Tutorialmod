using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Tutorialmod.Items.Material;

namespace Tutorialmod.Items.Weapon.RBowClass
{
	public class BowOfLight : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoot out barrage of fire type arrow along with your arrow, have a chance to shoot out a phoenix" +
                "\n Alt click to shoot a powerful Phoenix");
		}

		public override void SetDefaults() {
			Item.damage = 28;
			Item.crit = 15;
			Item.DamageType = DamageClass.Ranged;
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
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PureSilver>(), 4);
			recipe.AddIngredient(ItemID.Pearlwood, 60);
			recipe.AddIngredient(ItemID.Topaz, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
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

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(source, position, velocity, ProjectileID.DD2PhoenixBowShot, damage * 4, knockback, player.whoAmI);
			}
			else
			{
				{
					for (int i = 0; i < 5; i++)
					{
						Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(6));
						perturbedSpeed.X += Main.rand.Next(-5, 5);
						perturbedSpeed.Y += Main.rand.Next(-5, 5);
						type = Main.rand.Next(new int[] { type, ProjectileID.CursedArrow, ProjectileID.FrostburnArrow, ProjectileID.FireArrow });
						Projectile.NewProjectile(source, position, velocity, type, damage * 4, knockback, player.whoAmI);
					}
				}
				int o = Main.rand.Next(1, 5);
				if (o == 2)
				{
					Projectile.NewProjectile(source, position, velocity, ProjectileID.DD2PhoenixBowShot, damage * 4, knockback, player.whoAmI);
				}
			}
			return false;
		}
	}
}
