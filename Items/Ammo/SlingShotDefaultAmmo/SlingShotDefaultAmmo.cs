using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SlingShotDefaultAmmo
{
	public class SlingShotDefaultAmmo : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("StonePebble");
            Tooltip.SetDefault("a modified stone ? kinda in a way ig\n Can be use with slingshot for greater damage");
		}

		public override void SetDefaults() {
			Item.damage = 5;
            Item.useStyle = 1;
			Item.summon = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 15;
			Item.height = 15;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.maxStack = 999;
			Item.consumable = true;
            Item.knockBack = 3.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.White;
			Item.shoot = Mod.Find<ModProjectile>("SlingShotDefaultAmmoProjectile").Type;
			Item.shootSpeed = 9f;
			Item.ammo = Item.type;             
		}

		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
