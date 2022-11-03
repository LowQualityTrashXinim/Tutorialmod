using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon
{
    public class WoodenStick : ModItem
    {
        float Counter = 0f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Stick");
            Tooltip.SetDefault("Hold a hidden power? or not");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.melee = true;
            Item.width = 107;
            Item.height = 4;
            Item.crit = 2;
            Item.useStyle = 1;
            Item.shootSpeed = 3.7f;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.knockBack = 6.5f;
            Item.rare = 1;
            Item.value = 0;

            Item.melee = true;
            Item.noMelee = false;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.shoot = Mod.Find<ModProjectile>("WoodenStickP2").Type;
        }

        //double use here

        public override bool Shoot(Player player,ref Vector2 position,ref float speedX,ref float speedY,ref int type,ref int damage,ref float knockBack)
        {
            Counter++;
            switch (Counter)
            {
                case 1:
                    Item.noMelee = false;
                    Item.noUseGraphic = false;
                    Item.useStyle = 1;
                    break;
                case 2:
                    Item.useStyle = 5;
                    Item.noMelee = true;
                    Item.noUseGraphic = true;
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("WoodenStickP").Type, damage, knockBack, player.whoAmI);
                    break;
                case 3:
                    Item.useStyle = 5;
                    Item.noMelee = true;
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("WoodenStickP2").Type, damage, knockBack, player.whoAmI);
                    break;
            }
            if (Counter == 3)
            { Counter = 0; }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(target.Center,new Vector2(0,0), Mod.Find<ModProjectile>("impactProjectile").Type, (int)(damage*0.5f), knockback*2, player.whoAmI);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            //recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.DirtBlock, 200000000);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}