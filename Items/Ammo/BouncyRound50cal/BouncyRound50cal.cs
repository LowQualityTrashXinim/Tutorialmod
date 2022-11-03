using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.BouncyRound50cal
{
	public class BouncyRound50cal : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink Slime Ball");
            Tooltip.SetDefault("Bouncy boing boing\n Can be use with slingshot for greater damage");
		}

		public override void SetDefaults() {
			Item.damage = 23;
            Item.useStyle = 1;
			Item.summon = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 13;
			Item.height = 13;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.maxStack = 999;
			Item.consumable = true;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("BouncyRound50calP").Type;
			Item.shootSpeed = 15f;
			Item.ammo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
        }

		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.PinkGel,2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 90);
        }
	}
}
