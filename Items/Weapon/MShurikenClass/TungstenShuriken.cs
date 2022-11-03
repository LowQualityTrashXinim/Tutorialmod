using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class TungstenShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Shuriken");
            Tooltip.SetDefault("i'm not sure i like this\nAlt Click to throw 5 shuriken that is slightly inaccurate");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.ranged = true;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
            Item.width = 19;
            Item.height = 19;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 1.6f;
            Item.value = 50;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = Mod.Find<ModProjectile>("TungstenShurikenP").Type;
            Item.shootSpeed = 21f;
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
                Item.useTime = 5;
                Item.useAnimation = 25;
                Item.reuseDelay = 30;
                Item.shootSpeed = 15f;
                Item.shoot = Mod.Find<ModProjectile>("TungstenShurikenP").Type;
            }
            else
            {
                Item.useAnimation = 14;
                Item.useTime = 14;
                Item.shootSpeed = 22f;
                Item.reuseDelay = 0;
                Item.shoot = Mod.Find<ModProjectile>("TungstenShurikenP").Type;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9));
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.TungstenBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
