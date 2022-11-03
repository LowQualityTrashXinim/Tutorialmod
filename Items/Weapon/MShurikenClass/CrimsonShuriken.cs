using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class CrimsonShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Spreader");
            Tooltip.SetDefault("Absorb more, heal more\nAlt click to throw steam of Crimson Spreader");
		}

		public override void SetDefaults() {
			Item.damage = 25;
            Item.ranged = true;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.width = 66;
			Item.height = 66;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("CrimsonShurikenP").Type;
			Item.shootSpeed = 25f;
            Item.reuseDelay = 0;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 4;
                Item.useAnimation = 12;
                Item.shootSpeed = 17f;
                Item.reuseDelay = 12;
                Item.autoReuse = true;
                Item.shoot = Mod.Find<ModProjectile>("CrimsonShurikenP2").Type;
            }
            else
            {
                Item.useAnimation = 10;
                Item.useTime = 10;
                Item.autoReuse = false;
                Item.reuseDelay = 0;
                Item.shootSpeed = 25f;
                Item.shoot = Mod.Find<ModProjectile>("CrimsonShurikenP").Type;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;

            }
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
