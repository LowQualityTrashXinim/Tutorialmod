using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class DoorSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Door on a stick");
        }

        public override void SetDefaults()
        {
            Item.melee = true;
            Item.autoReuse = true;
            Item.useStyle = 1;

            Item.width =82;
            Item.height =82;

            Item.useTime = 20;
            Item.useAnimation = 20;

            Item.damage = 20;
            Item.knockBack = 10f;

            Item.rare = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(ItemID.WoodenDoor, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
