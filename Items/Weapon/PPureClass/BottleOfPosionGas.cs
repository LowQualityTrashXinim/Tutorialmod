using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.PPureClass
{
	public class BottleOfPosionGas : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottle Of Toxic");
            Tooltip.SetDefault("Quite toxic, not toxic enough to compete with russian");
        }

        public override void SetDefaults()
        {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			Item.shootSpeed = 20f;
			Item.damage = 10;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.width = 18;
			Item.height = 22;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.White;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.ranged = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 5);

			Item.shoot = Mod.Find<ModProjectile>("BOPGProjectiles").Type;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(Mod);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.Cloud, 10);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
