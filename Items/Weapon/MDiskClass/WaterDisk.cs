using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.MDiskClass
{
    public class WaterDisk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Water flow through the wind? wait, what");
        }
        public override void SetDefaults()
        {
            Item.melee = true;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useStyle = 1;
            Item.shootSpeed = 9f;
            Item.shoot = Mod.Find<ModProjectile>("WaterDiskP").Type;
            Item.damage = 14;
            Item.knockBack = 4.5f;
            Item.width = 46;
            Item.height = 46;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.WaterBucket, 3);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
