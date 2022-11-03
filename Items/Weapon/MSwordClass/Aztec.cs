using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
	public class Aztec : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Belong to the ancient cilvilization of Aztec, tho it is their fault that they got stolen\n True melee special property : Grant Semi Rage Buff when dealing damage to enemy");
		}

		public override void SetDefaults() 
		{
			Item.damage = 29;
			Item.melee = true;
			Item.width = 68;
			Item.height = 68;
            Item.crit = 12;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.knockBack = 2.5f;
			Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("JungleWrath").Type, 180);
            player.AddBuff(Mod.Find<ModBuff>("SemiRage").Type, 60);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.BladeofGrass, 1);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.Vine, 3);
            recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}