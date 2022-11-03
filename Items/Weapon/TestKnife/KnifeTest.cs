using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.TestKnife
{
    public class TestKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TestKnife");
            Tooltip.SetDefault("The Really weird knife");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.melee = true;
            Item.width = 33;
            Item.height = 37;
            Item.useTime = 7;
            Item.useAnimation = 25;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 22, 50, 0);
            Item.rare = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = Mod.Find<ModProjectile>("KnifeTestP").Type;
            Item.shootSpeed = 40f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.DirtBlock, 200000000);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}