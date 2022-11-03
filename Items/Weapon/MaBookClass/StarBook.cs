using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MaBookClass
{
	public class StarBook : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Star, Star everywhere \n shoot out many star");
		}

		public override void SetDefaults() {
			Item.damage = 6;
			Item.magic = true;
			Item.mana = 7;
			Item.width = 29;
			Item.height = 32;
			Item.useTime = 10;
            Item.useAnimation = 20;
            Item.crit = 7;
            Item.useStyle = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1.5f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<StarBookP>();
			Item.shootSpeed = 20f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddIngredient(ItemID.Goldfish, 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberprojectile = 1 + Main.rand.Next(1, 3);
			for (int i = 0; i < numberprojectile; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				speedX = perturbedSpeed.X;
				speedY = perturbedSpeed.Y;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}