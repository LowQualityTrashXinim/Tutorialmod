using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class HellFireShortSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellFireSword");
            Tooltip.SetDefault("1000 degree hot knife challenge");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.melee = true;
            Item.width = 23;
            Item.height = 25;
            Item.crit = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 3.7f;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.knockBack = 2.5f;
            Item.rare = 1;
            Item.value = 0;
            Item.UseSound = SoundID.Item1;
        }

        //double use here

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.UseSound = SoundID.Item1;
                Item.shoot = ModContent.ProjectileType<HellFireShortSwordP>();
                Item.noMelee = true;
                Item.noUseGraphic = true;
                Item.autoReuse = false;
                Item.useStyle = ItemUseStyleID.Shoot;
            }
            else
            {
                Item.useStyle = 1;
                Item.noMelee = false;
                Item.noUseGraphic = false;
                Item.shoot = ProjectileID.None;
                Item.autoReuse = true;
            }
            return base.CanUseItem(player);
            //return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 90);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            //recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}