using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tutorialmod.Items.Accessories.MashedOfCopper
{
    public class MashedOfCopper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increase defense by 6! \nHave a chance to shoot out a copper dagger\nBurst out 10 home in explosive copper when damaged");
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
            player.statDefense += 6;
            player.GetModPlayer<TutorialmodPlayer>().MashedOfCopper = true;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            // When the item is given a prefix, only roll the best modifiers for accessories
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.CopperGreaves, 1);
            recipe.AddIngredient(ItemID.CopperChainmail, 1);
            recipe.AddIngredient(ItemID.CopperHelmet, 1);
            recipe.AddIngredient(ItemID.CopperBow, 1);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ItemID.CopperBroadsword, 1);
            recipe.AddIngredient(ItemID.CopperPickaxe, 1);
            recipe.AddIngredient(ItemID.CopperHammer, 1);
            recipe.AddIngredient(ItemID.CopperAxe, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
