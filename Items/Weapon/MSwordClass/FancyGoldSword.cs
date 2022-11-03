using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class FancyGoldSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The Cooler GoldSword\n True melee special property : Grant Semi Rage Buff when dealing damage to enemy");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.melee = true;
            Item.width = 56;
            Item.height = 56;
            Item.crit = 15;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(Mod.Find<ModBuff>("SemiRage").Type, 60);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.SilverBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}