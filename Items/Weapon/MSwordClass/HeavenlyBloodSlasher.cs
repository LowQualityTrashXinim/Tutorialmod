using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
	public class HeavenlyBloodSlasher : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Heavenly Blood Slasher");
            Tooltip.SetDefault(" Forged by fury of heaven \n True melee special property : Grant Rage Buff when dealing damage to enemy ");
		}

		public override void SetDefaults() 
		{
			Item.damage = 45;
			Item.melee = true;
			Item.width = 49;
			Item.height = 50;
            Item.crit = 15;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 100;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(Mod.Find<ModBuff>("Rage").Type, 30);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(Mod, "PureSilver", 12);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.Pearlwood, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}