
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tutorialmod.Items.Weapon.SlingShot
{
    public class AncientsSecret : ModItem
    {
        public float Counter = 0f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient's Secret");
            Tooltip.SetDefault("description here\nWhen holding, increase 20% minion damage\nAnd when hold long enough will shoot out storm of sand ball");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.summon = true;
            Item.width = 33;
            Item.height = 33;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.channel = true;
            Item.shootSpeed = 10.2f;
            Item.useAmmo = Mod.Find<ModItem>("SlingShotDefaultAmmo").Type;
            Item.shoot = Mod.Find<ModProjectile>("SlingShotDefaultAmmoProjectile").Type;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(Mod);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 5);
            recipe.AddIngredient(ItemID.YellowString, 1);
            recipe.AddIngredient(ItemID.AntlionMandible, 25);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        public override void HoldItem(Player player)
        {
            player.AddBuff(Mod.Find<ModBuff>("DesertSupport").Type, 210);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 7;
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .7f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Mod.Find<ModProjectile>("SandBulletP").Type, damage, knockBack, player.whoAmI);
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}




