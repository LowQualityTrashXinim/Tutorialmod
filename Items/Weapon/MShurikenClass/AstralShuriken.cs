using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
	public class AstralShuriken : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Impossible, How did you even get this ...");
		}

		public override void SetDefaults() {
			Item.damage = 35;
			Item.crit = 12;
			Item.DamageType = DamageClass.Ranged;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.width = 37;
			Item.height = 37;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.knockBack = 2.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<AstralShurikenP>();
			Item.shootSpeed = 5f;
		}

        public override void AddRecipes() 
		{

		}
	}
}
