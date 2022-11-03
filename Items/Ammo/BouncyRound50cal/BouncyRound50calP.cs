using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.BouncyRound50cal
{
    public class BouncyRound50calP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 13;
            Projectile.height = 13;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 25;
            Projectile.timeLeft = 600;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            float MinusPenetrate = Projectile.penetrate * -1;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.penetrate > 10)
                {
                    Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
                    if (Projectile.velocity.X != oldVelocity.X)
                    {
                        Projectile.velocity.X = -oldVelocity.X * 1.5f;
                    }
                    if (Projectile.velocity.Y != oldVelocity.Y)
                    {
                        Projectile.velocity.Y = -oldVelocity.Y * 1.15f;
                    }
                    // capping maximum velocity
                    if (Projectile.velocity.X > Projectile.penetrate)
                    {
                        Projectile.velocity.X = Projectile.penetrate;
                    }
                    if (Projectile.velocity.X < MinusPenetrate)
                    {
                        Projectile.velocity.X = MinusPenetrate;
                    }
                    if (Projectile.velocity.Y > Projectile.penetrate)
                    {
                        Projectile.velocity.Y = Projectile.penetrate;
                    }
                    if (Projectile.velocity.Y < MinusPenetrate)
                    {
                        Projectile.velocity.Y = MinusPenetrate;
                    }
                }
            }
            //slow down son
            if (Projectile.penetrate < 10)
            {
                Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X * .5f;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y * .5f;
                }
            }
            return false;
        }
    }
}