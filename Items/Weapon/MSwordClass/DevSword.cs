using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class DevSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Be Fear");
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.melee = true;
            Item.width = 50;
            Item.height = 46;
            Item.crit = 999;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = 1;
            Item.knockBack = 20;
            Item.value = 10000;
            Item.rare = 10;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.DirtBlock, 200000000);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)//Alow for alt uses
        {
            if (player.altFunctionUse == 2)//code for shooting projectiles
            {
                Item.shoot = ModContent.ProjectileType<SuperChargedP>();
                Item.useTime = 10;//0.5s use time
                Item.useAnimation = 10;
                Item.noUseGraphic = true;
                Item.noMelee = true;
                Item.autoReuse = true;
                Item.shootSpeed = 20f;
            }
            else//code for dealing damage as a sword
            {
                Item.useTime = 5;
                Item.useAnimation = 5;
                Item.noUseGraphic = false;
                Item.noMelee = false;
                Item.shoot = 0;
            }
            return base.CanUseItem(player);
        }
        //supposely, this code were is made to create random spawn projectile posistion, but i suck
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

                for (int m = 0; m < 1; m++)//This code responsible for shooting out homing projectile, name of the projectile may change
            {
                float numberProjectiles = 8; // 30 shots, can you outsmart home in bullet ?
                float rotation = MathHelper.ToRadians(360);
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // divide by 0 = death
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            return false;

        }
    }
}