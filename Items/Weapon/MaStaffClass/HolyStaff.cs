using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MaStaffClass
{
	public class HolyStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Slowly purify your foe with deadly force");
		}

		public override void SetDefaults() {
			Item.damage = 25;
			Item.magic = true;
			Item.mana = 25;
			Item.width = 41;
			Item.height = 41;
			Item.useTime = 60;
            Item.useAnimation = 60;
            Item.crit = 7;
            Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 0.4f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<HolyStaffOrb>();
			Item.shootSpeed = 2f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Pearlwood, 50);
			recipe.AddIngredient(Mod, "PureSilver", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}