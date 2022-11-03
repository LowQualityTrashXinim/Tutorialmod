using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class PlatinumUpgradeSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Long Sword");
            Tooltip.SetDefault("A Upgrade of old trusty BroadSword");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.melee = true;
            Item.width = 48;
            Item.height = 48;
            Item.crit = 10;
            Item.useStyle = 1;
            Item.knockBack = 2.3f;
            Item.value = 100;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(Mod.Find<ModBuff>("SemiRage").Type, 35);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}