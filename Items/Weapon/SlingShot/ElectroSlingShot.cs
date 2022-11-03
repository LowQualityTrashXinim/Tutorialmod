using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.SlingShot
{
    public class ElectroSlingShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temple Scouter");
            Tooltip.SetDefault("Temple vibe lol, for now it give jungle calm buff lol");
        }

        public override void SetDefaults()
        {
            Item.damage = 54;
            Item.summon = true;
            Item.width = 48;
            Item.height = 50;
            Item.useTime = 30;
            Item.useAnimation = 30; //(60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5.2f;
            Item.value = 10000;
            Item.channel = true;
            Item.rare = ItemRarityID.Blue; // the color that the item's name will be in-game
            Item.autoReuse = false;
            Item.noUseGraphic = false;
            Item.channel = true;
            Item.shootSpeed = 9.5f;
            Item.useAmmo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
            Item.shoot = Mod.Find<ModProjectile>("SlingShotDefaultAmmoProjectile").Type;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
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




