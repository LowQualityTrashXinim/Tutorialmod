using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class BladeOfStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("StarBlade");
            Tooltip.SetDefault("BladeOfStar");
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Melee;
            Item.width = 61;
            Item.height = 64;
            Item.crit = 5;
            Item.useStyle = 1;
            Item.knockBack = 1.5f;
            Item.value = 100;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<BladeOfStarP>();
            Item.shootSpeed = 25f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position = Main.MouseWorld;
            position.Y -= 750;
            position.X += Main.rand.Next(-200, 200);

            Vector2 DistanceFromProjToMouse = Main.MouseWorld - position;
            Vector2 DirectionFromProjToMouse = DistanceFromProjToMouse.SafeNormalize(Vector2.UnitX);
            Vector2 speed = DirectionFromProjToMouse * 14f;

            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FallenStar, 10)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.Starfury)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}