using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Material
{
	public class PureSilver : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Purest Silver");
		}

		public override void SetDefaults() {
            Item.width = 33;
			Item.height = 27;
			Item.maxStack = 9999;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverBar, 2);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}
