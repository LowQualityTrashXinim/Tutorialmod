using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class PlatinumShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Shuriken");
            Tooltip.SetDefault("A+ Quality, never fail me\nAlt Click to throw 6 shuriken that is slightly inaccurate");
		}

		public override void SetDefaults() {
			Item.damage = 16;
            Item.ranged = true;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 2.3f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
			Item.shootSpeed = 23f;
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
                Item.useTime = 4;
                Item.useAnimation = 24;
                Item.reuseDelay = 35;
                Item.shootSpeed = 19f;
                Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 8;
                Item.useTime = 8;
                Item.shootSpeed = 25f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("PlatinumShurikenP").Type;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
            }
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 80);
			recipe.AddRecipe();
		}
	}
}
