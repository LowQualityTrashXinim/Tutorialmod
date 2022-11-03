using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class GodSlapHand : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 120;
            Projectile.melee = true;
            Projectile.alpha = 155;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + (MathHelper.PiOver2)/2;
        }
    }
}
