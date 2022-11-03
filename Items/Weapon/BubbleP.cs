using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon
{
    public class BubbleP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 25;
        }

        public override void AI()
        {
            if (Projectile.timeLeft == 10)
            {
                Projectile.velocity.X -= Projectile.velocity.X;
                Projectile.velocity.Y -= Projectile.velocity.Y;
            }
            if (Projectile.timeLeft != 0)
            {
                Projectile.scale -= 0.01f;
            }
        }

    }
}