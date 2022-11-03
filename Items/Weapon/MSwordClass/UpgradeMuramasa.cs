using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class UpgradeMuramasa : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atlantis");
            Tooltip.SetDefault("Forged with the calmness of the sea and the rage during thunder\n True melee special property : Grant Semi Rage Buff when dealing damage to enemy");
        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.melee = true;
            Item.width = 61;
            Item.height = 64;
            Item.crit = 5;
            Item.useStyle = 1;
            Item.knockBack = 1.6f;
            Item.value = 100;
            Item.useTime = 13;
            Item.useAnimation = 13;
            Item.rare = ItemRarityID.Green;
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
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Trident, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}