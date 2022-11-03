using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.RGunClass
{
    public class mGun : ModItem
    {
        public int counter = 0;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("oh hey, i seen this somewhere");
        }

        public override void SetDefaults()
        {
            Item.damage = 10; 
            Item.ranged = true; 
            Item.width = 68; 
            Item.height = 38;
            Item.useTime = 5; 
            Item.useAnimation = 30;
            Item.reuseDelay = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; 
            Item.knockBack = 1f;
            Item.value = 10000; 
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 5;
            Item.shootSpeed = 5f; 
            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 2);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int[] type1 = new int[] { Mod.Find<ModProjectile>("Bcharacter").Type, Mod.Find<ModProjectile>("Ucharacter").Type, Mod.Find<ModProjectile>("Lcharacter").Type, Mod.Find<ModProjectile>("Lcharacter").Type, Mod.Find<ModProjectile>("Echaracter").Type, Mod.Find<ModProjectile>("Tcharacter").Type };
            Vector2 speed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            Projectile.NewProjectile(position.X, position.Y - 6, speed.X, speed.Y, type1[counter], damage, knockBack, player.whoAmI);
            counter++;
            if (counter == 6)
            { counter = 0; }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.Handgun, 1);
            recipe.AddIngredient(ItemID.IceBlock, 50);
            recipe.AddIngredient(ItemID.Lens, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
