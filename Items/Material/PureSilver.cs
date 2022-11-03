using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
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
			ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.SilverBar, 2);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 2);
			recipe.AddRecipe();

			/*
			// Start a new Recipe. (Prepend with "ModRecipe " if 1st recipe in code block.)
			recipe = new ModRecipe(mod);
			// Add a Vanilla Ingredient. 
			// Look up ItemIDs: https://github.com/tModLoader/tModLoader/wiki/Vanilla-Item-IDs
			// To specify more than one ingredient, use multiple recipe.AddIngredient() calls.
			recipe.AddIngredient(ItemID.DirtBlock);
			// An optional 2nd argument will specify a stack of the item. 
			recipe.AddIngredient(ItemID.Acorn, 10);
			// We can also specify the current item as an ingredient
			recipe.AddIngredient(this, 2);
			// Add a Mod Ingredient. Do not attempt ItemID.EquipMaterial, it's not how it works.
			recipe.AddIngredient(mod, "EquipMaterial", 3);
			// an alternate approach to the above.
			recipe.AddIngredient(ItemType<EquipMaterial>(), 3);
			// RecipeGroups allow you create a recipe that accepts items from a group of similar ingredients. For example, all varieties of Wood are in the vanilla "Wood" Group
			recipe.AddRecipeGroup("Wood"); // check here for other vanilla groups: https://github.com/tModLoader/tModLoader/wiki/Intermediate-Recipes#using-existing-recipegroups
			// Here is using a mod recipe group. Check out ExampleMod.AddRecipeGroups() to see how to register a recipe group.
			recipe.AddRecipeGroup("ExampleMod:ExampleItem", 2);
			// To specify a crafting station, specify a tile. Look up TileIDs: https://github.com/tModLoader/tModLoader/wiki/Vanilla-Tile-IDs
			recipe.AddTile(TileID.WorkBenches);
			// A mod Tile example. To specify more than one crafting station, use multiple recipe.AddTile() calls.
			recipe.AddTile(mod, "ExampleWorkbench");
			// There is a limit of 14 ingredients and 14 tiles to a recipe.
			// Special
			// Water, Honey, and Lava are not tiles, there are special bools for those. Also needSnowBiome. Water also specifies that it works with Sinks.
			recipe.needHoney = true;
			// Set the result of the recipe. You can use stack here too. Since this is in a ModItem class, we can use "this" to specify this item as the result.
			recipe.SetResult(this, 999); // or, for a vanilla result, recipe.SetResult(ItemID.Muramasa);
			// Finish your recipe
			recipe.AddRecipe();
			*/
		}
	}
}