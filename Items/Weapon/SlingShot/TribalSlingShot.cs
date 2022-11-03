using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.SlingShot
{
    public class TribalSlingShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tribal shot");
            Tooltip.SetDefault("Take a shot, don't miss or you will let your prey feast upon you\nWhen holding, grant 10% minion damage and a extra minion slot");
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.summon = true;
            Item.width = 48;
            Item.height = 50;
            Item.useTime = 42;
            Item.useAnimation = 42; //(60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5.2f;
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
            recipe.AddIngredient(ItemID.Vine, 4);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(Mod.Find<ModBuff>("JungleCalm").Type, 210);
        }
    }
}




