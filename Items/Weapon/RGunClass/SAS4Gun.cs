using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.RGunClass
{
    public class SAS4Gun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Black Varient");
        }

        public override void SetDefaults()
        {
            Item.damage = 35; 
            Item.DamageType = DamageClass.Ranged;
            Item.width = 130;
            Item.height = 34; 
            Item.useTime = 5;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.noMelee = true; 
            Item.knockBack = 0; 
            Item.value = 10000; 
            Item.rare = ItemRarityID.Red; 
            Item.UseSound = SoundID.Item11; 
            Item.autoReuse = true;
            Item.shoot = 5;
            Item.shootSpeed = 50f; 
            Item.useAmmo = AmmoID.Bullet; 
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

            int numberProjectiles = 2; // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
                float scale = 1f - (Main.rand.NextFloat() * .10f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y,ModContent.ProjectileType<PlasmaProjectile>(), damage, knockback, player.whoAmI);
            }

			return false;
        }// return false because we don't want tmodloader to shoot projectile

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-30, 2);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 200000000);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}