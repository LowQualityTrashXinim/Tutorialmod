using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SandBullet
{
	public class SandBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SandBall");
            Tooltip.SetDefault("didn't know sand have ball\n Can be use with slingshot for greater damage");
		}

		public override void SetDefaults() {
			Item.damage = 1;
            Item.useStyle = 1;
			Item.summon = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 18;
			Item.height = 18;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 999;
			Item.consumable = true;
            Item.knockBack = 1.5f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = Mod.Find<ModProjectile>("SandBulletP").Type;
			Item.shootSpeed = 9f;
            Item.ammo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
        }

		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.SandBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
