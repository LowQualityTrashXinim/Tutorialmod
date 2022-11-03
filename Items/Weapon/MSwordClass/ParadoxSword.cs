using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class ParadoxSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ParadoxSword");
            Tooltip.SetDefault("Sparking with multiple flames \n True melee special property : Grant Rage Buff when dealing damage to enemy");
        }

        public override void SetDefaults()
        {
            Item.damage = 54; // no longer nice
            Item.melee = true;
            Item.width = 60; // 60
            Item.height = 60; // 60
            Item.crit = 25;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(Mod,"PureSilver", 12);
            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(ItemID.Pearlwood, 50);
            recipe.AddIngredient(ItemID.Ruby, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
            target.AddBuff(BuffID.ShadowFlame, 180);
            target.AddBuff(BuffID.Frostburn, 180);
            target.AddBuff(BuffID.CursedInferno, 180);
            target.AddBuff(BuffID.Burning, 180);
            target.AddBuff(BuffID.Oiled, 180);
            player.AddBuff(Mod.Find<ModBuff>("Rage").Type, 30);
        }
    }
}