using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Accessories.MashedOfCopper
{
    public class MoCDustP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 100;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 20;
        }

        public override void AI()
        {
            if (Projectile.timeLeft == 12)
            {
                Projectile.velocity.X -= Projectile.velocity.X;
                Projectile.velocity.Y -= Projectile.velocity.Y;
            }
            if (Projectile.timeLeft != 0)
            {
                Projectile.rotation += 0.2f * (float)Projectile.direction;
                Projectile.scale -= 0.035f;
                Projectile.alpha += 1;
            }
        }

    }
}