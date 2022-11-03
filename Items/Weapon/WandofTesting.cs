using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon
{
	public class WandofTesting : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Weapon of not mass destruction but mass nice number");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.damage = 69;
			Item.magic = true;
			Item.mana = 69;
			Item.width = 29;
			Item.height = 32;
			Item.useTime = 69;
            Item.useAnimation = 69;
            Item.crit = 65;
            Item.useStyle = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 69f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<SoundBlastP>();
			Item.shootSpeed = 69f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(Mod.Find<ModBuff>("die").Type, 69);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Book, 69420);
            recipe.AddIngredient(ItemID.FallenStar, 69420);
            recipe.AddIngredient(ItemID.ManaCrystal, 69420);
            recipe.AddIngredient(ItemID.Goldfish, 69420);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}