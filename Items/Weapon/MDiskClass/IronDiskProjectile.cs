using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MDiskClass
{
    public class IronDiskProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.melee = true;
        }
    }
}