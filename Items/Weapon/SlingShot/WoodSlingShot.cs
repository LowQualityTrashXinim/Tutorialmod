using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.SlingShot
{
    public class WoodSlingShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wood Sling Shot");
            Tooltip.SetDefault("The Classic of everyone childhood\nWhen holding, grant Bewitched buff");
        }

        public override void SetDefaults()
        {
            Item.damage = 3;
            Item.summon = true;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 45;
            Item.useAnimation = 45; //(60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5;
            Item.value = 10000;
            Item.channel = true;
            Item.rare = ItemRarityID.Blue; // the color that the item's name will be in-game
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.channel = true;
            Item.shoot = Mod.Find<ModProjectile>("SlingShotDefaultAmmoProjectile").Type;
            Item.shootSpeed = 8.5f;
            Item.useAmmo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.WhiteString, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Bewitched, 150);
        }
    }
}




