using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.RBoomerang
{
    public class StarBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Extremely Inconsistent but also conistent");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useStyle = 1;
            Item.shootSpeed = 12.5f;
            Item.shoot = ModContent.ProjectileType<StarBoomerangP>();
            Item.damage = 15;
            Item.knockBack = 2.5f;
            Item.width = 24;
            Item.height = 44;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EnchantedBoomerang)
                .AddIngredient(ItemID.FallenStar, 5)
                .AddIngredient(ItemID.MeteoriteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
