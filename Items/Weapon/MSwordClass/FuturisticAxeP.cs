using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    class FuturisticAxeP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 84;
            Projectile.height = 84;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 30;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation += 5f;

            if (Projectile.timeLeft < 5)
            {
                Projectile.timeLeft = 4;
                Vector2 newMove = player.Center - Projectile.Center;
                Vector2 SafeReturn = newMove.SafeNormalize(Vector2.UnitX);
                Projectile.velocity = SafeReturn * 30;
                
                float distance = 50;
                float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                if (distanceTo < distance)
                {
                    Projectile.timeLeft = 0;
                }
            }
        }
    }
}
