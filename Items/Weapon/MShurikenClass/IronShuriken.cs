using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class IronShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Shuriken");
            Tooltip.SetDefault("Isn't it just worse shuriken ?\nAlt Click to throw 4 shuriken that is slightly inaccurate");
		}

		public override void SetDefaults() {
			Item.damage = 9;
            Item.ranged = true;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.knockBack = 1.1f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("IronShurikenP").Type;
			Item.shootSpeed = 18f;
            Item.consumable = true;
            Item.maxStack = 999;
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
                Item.useTime = 6;
                Item.useAnimation = 24;
                Item.reuseDelay = 30;
                Item.shootSpeed = 11f;
                Item.shoot = Mod.Find<ModProjectile>("IronShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 19;
                Item.useTime = 19;
                Item.shootSpeed = 18f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("IronShurikenP").Type;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(14));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
            }
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
