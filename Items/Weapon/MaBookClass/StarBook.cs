using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MaBookClass
{
	public class StarBook : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Star, Star everywhere \n shoot out many star");
		}

		public override void SetDefaults() {
			
			Item.width = 29;
			Item.height = 32;

			Item.useTime = 10;
            Item.useAnimation = 20;
            
			Item.mana = 7;
			Item.crit = 7;
			Item.damage = 6;
			Item.shootSpeed = 20f;
			Item.knockBack = 1.5f;
			Item.value = 10000;

            Item.useStyle = ItemUseStyleID.Shoot;
			Item.DamageType = DamageClass.Magic;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ProjectileType<StarBookP>();
			Item.noMelee = true;
			Item.autoReuse = true;
		}

		public override void AddRecipes() {
			CreateRecipe()
			.AddIngredient(ItemID.Book, 10)
			.AddIngredient(ItemID.FallenStar, 15)
			.AddIngredient(ItemID.ManaCrystal, 3)
			.AddIngredient(ItemID.Goldfish, 1)
			.AddTile(TileID.Bookcases)
			.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			int numberprojectile = 1 + Main.rand.Next(1, 3);
			for (int i = 0; i < numberprojectile; i++)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));
				velocity.X = perturbedSpeed.X;
				velocity.Y = perturbedSpeed.Y;
				Projectile.NewProjectile(source,position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
	}
}