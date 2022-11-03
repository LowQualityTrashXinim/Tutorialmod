using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.PPureClass
{
    public class BladeForm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TestWandSword");
            Tooltip.SetDefault("Testing Sword + wand");
        }
        public override void SetDefaults()
        {
            Item.melee = true;
            Item.damage = 100;
            Item.knockBack = 10f;
            Item.useStyle = 1;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 60;
            Item.height = 60;
            Item.rare = ItemRarityID.Green;
            Item.shoot = Mod.Find<ModProjectile>("UpgradeMuramasaP").Type;
            Item.shootSpeed = 0;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 MouseToPlayer = player.Center - Main.MouseWorld;
            Vector2 SafeMovement = MouseToPlayer.SafeNormalize(Vector2.UnitX);
            Vector2 MovementTo = SafeMovement * 10f;
            Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, MovementTo.X, MovementTo.Y, Mod.Find<ModProjectile>("UpgradeMuramasaP").Type,damage, knockBack, player.whoAmI);
            return false;
        }
    }
}
