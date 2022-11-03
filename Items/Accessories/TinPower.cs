using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tutorialmod.Items.Accessories
{
    public class TinPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increase defense by 6!");
        }

        public override void SetDefaults()
        {
            Item.width = 27;
            Item.height = 27;
            Item.accessory = true;
            Item.value = Item.sellPrice(silver: 100);
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions++;
            player.statDefense += 6;
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("TinShortswordP").Type] < 1)
            {
                player.GetModPlayer<TutorialmodPlayer>().TinPower = true;
            }
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            // When the item is given a prefix, only roll the best modifiers for accessories
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.TinGreaves, 1);
            recipe.AddIngredient(ItemID.TinChainmail, 1);
            recipe.AddIngredient(ItemID.TinHelmet, 1);
            recipe.AddIngredient(ItemID.TinBow, 1);
            recipe.AddIngredient(ItemID.TinShortsword, 1);
            recipe.AddIngredient(ItemID.TinBroadsword, 1);
            recipe.AddIngredient(ItemID.TinPickaxe, 1);
            recipe.AddIngredient(ItemID.TinHammer, 1);
            recipe.AddIngredient(ItemID.TinAxe, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
