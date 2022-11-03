using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class BlazingMidNight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MidNightBlaze");
            Tooltip.SetDefault("The Night is Blazing with star and meteorite to hunt down your foe \nAnd what you have is a Meteorite shuriken");
        }

        public override void SetDefaults()
        {
            Item.damage = 47;
            Item.DamageType = DamageClass.Melee;
            Item.width = 61;
            Item.height = 64;
            Item.crit = 16;
            Item.useStyle = 1;
            Item.knockBack = 2.9f;
            Item.value = 100;
            Item.useTime = 60;
            Item.useAnimation = 15;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<BlazingMidNightP>();
            Item.shootSpeed = 10f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position = Main.MouseWorld;
            position.Y -= 550;
            position.X += Main.rand.Next(-200, 200);

            Vector2 DistanceFromProjToMouse = Main.MouseWorld - position;
            Vector2 DirectionFromProjToMouse = DistanceFromProjToMouse.SafeNormalize(Vector2.UnitX);
            Vector2 speed = DirectionFromProjToMouse * 17f;

            Projectile.NewProjectile(source,position.X, position.Y, speed.X, speed.Y, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<BladeOfStar>())
                .AddIngredient(ItemID.NightsEdge)
                .AddIngredient(ItemID.MeteoriteBar, 40)
                .AddTile(TileID.DemonAltar)
                .Register();
        }

    }
}