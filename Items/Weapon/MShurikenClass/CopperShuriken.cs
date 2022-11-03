using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class CopperShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Shuriken");
            Tooltip.SetDefault("C- for trying\nAlt Click to throw 3 shuriken that is slightly inaccurate");
		}

		public override void SetDefaults() {
			Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
			Item.width = 19;
			Item.height = 19;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.knockBack = 0.9f;
			Item.value = 50;
			Item.rare = ItemRarityID.Blue;
            Item.shoot = ModContent.ProjectileType<CopperShurikenP>();
			Item.shootSpeed = 16f;
            Item.consumable = true;
            Item.maxStack = 1000;
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
                Item.useTime = 5;
                Item.useAnimation = 15;
                Item.reuseDelay = 30;
                Item.shootSpeed = 9f;
                Item.shoot = Mod.Find<ModProjectile>("CopperShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 19;
                Item.useTime = 19;
                Item.shootSpeed = 16f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("CopperShurikenP").Type;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(16));
                velocity.X = perturbedSpeed.X;
                velocity.Y = perturbedSpeed.Y;
            }
            return true;
        }

        public override void AddRecipes() {
            CreateRecipe(999)
                .AddIngredient(ItemID.CopperBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
		}
	}
}
