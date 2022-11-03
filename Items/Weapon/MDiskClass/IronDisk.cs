using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.MDiskClass
{
    public class IronDisk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Iron Disc\nAlt click to fire out 4 disks deal 25% of original damage");
        }
        public override void SetDefaults()
        {
            Item.melee = true;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useStyle = 1;
            Item.shootSpeed = 12.5f;
            Item.shoot = Mod.Find<ModProjectile>("IronDiskProjectile").Type;
            Item.damage = 14;
            Item.knockBack = 2.5f;
            Item.width = 25;
            Item.height = 25;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 50;
                Item.useAnimation = 50;
            }
            else
            {
                Item.useAnimation = 25;
                Item.useTime = 25;
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.IronBar, 7);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                float rotation = MathHelper.ToRadians(30);
                float numProjectile = 4;
                position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
                for (int i = 0; i < numProjectile; i++)
                {
                    Vector2 NewSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProjectile - 1)));
                    Projectile.NewProjectile(position.X, position.Y, NewSpeed.X, NewSpeed.Y, Mod.Find<ModProjectile>("IronDiskProjectile").Type, (int)(damage * .55f), knockBack, player.whoAmI);
                }
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("IronDiskProjectile").Type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
