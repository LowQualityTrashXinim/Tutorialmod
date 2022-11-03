using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    class FuturisticAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It is just a better axe");
        }
        public override void SetDefaults()
        {
            Item.melee = true;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useStyle = 1;

            Item.width = 84;
            Item.height = 84;

            Item.useTime = 12;
            Item.useAnimation = 12;

            Item.damage = 50;
            Item.knockBack = 2f;
            Item.shootSpeed = 30f;

            Item.rare = 7;
            Item.axe = 200;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.AddBuff(Mod.Find<ModBuff>("Rage").Type, 30); 
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = Mod.Find<ModProjectile>("FuturisticAxeP").Type;
                Item.noMelee = true;
                Item.noUseGraphic = true;
            }
            else
            {
                Item.shoot = 0;
                Item.noMelee = false;
                Item.noUseGraphic = false;
            }
            return base.CanUseItem(player);
        }
    }
}
