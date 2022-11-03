using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class GoldUpgradeSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Long Sword");
            Tooltip.SetDefault("A Upgrade of old trusty BroadSword");
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.melee = true;
            Item.width = 56;
            Item.height = 56;
            Item.crit = 12;
            Item.useStyle = 1;
            Item.knockBack = 2.3f;
            Item.value = 100;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(Mod.Find<ModBuff>("SemiRage").Type, 32);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}