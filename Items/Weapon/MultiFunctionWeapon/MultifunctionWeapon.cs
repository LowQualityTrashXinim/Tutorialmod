using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tutorialmod.Items.Weapon.MultiFunctionWeapon
{
    class MultifunctionWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ScytheForm");
            Tooltip.SetDefault("ScytheForm");
        }
        public override void SetDefaults()
        {
            Item.melee = true;
            Item.autoReuse = false;

            Item.useStyle = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;

            Item.width = 100;
            Item.height = 92;

            Item.damage = 90;
            Item.knockBack = 3f;
        }
    }
}
