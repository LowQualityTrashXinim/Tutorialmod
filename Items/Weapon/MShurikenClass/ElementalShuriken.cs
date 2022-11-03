using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class ElementalShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Die");
		}

		public override void SetDefaults() {
			Item.damage = 20;
            Item.ranged = true;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.width = 37;
			Item.height = 37;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("ElementalShurikenP").Type;
			Item.shootSpeed = 10f;
		}

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(Mod, "DemonicShuriken", 1);
            recipe.AddIngredient(Mod, "CrimsonShuriken", 1);
            recipe.AddIngredient(Mod, "HellShuriken", 1);
            recipe.AddIngredient(Mod, "JungleShuriken", 1);
            recipe.AddIngredient(Mod, "Snowflake", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
