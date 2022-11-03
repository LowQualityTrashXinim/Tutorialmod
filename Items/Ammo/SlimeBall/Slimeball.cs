using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SlimeBall
{
	public class Slimeball : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Ball");
            Tooltip.SetDefault("sticky ? nah, tho wish it was boing boing\n Can be use with slingshot for greater damage");
		}

		public override void SetDefaults() {
			Item.damage = 3;
            Item.useStyle = 1;
			Item.summon = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 54;
			Item.height = 54;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.maxStack = 999;
			Item.consumable = true;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("SlimeballP").Type;
			Item.shootSpeed = 8f;
			Item.ammo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
			Item.scale = 0.5f;
		}

		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Gel, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 2);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 90);
        }
	}
}
