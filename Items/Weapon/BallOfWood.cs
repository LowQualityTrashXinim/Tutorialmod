using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class BallOfWood : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 120;
            Projectile.ranged = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X * .7f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y * .7f;
            }
            for (int t = 0; t < 6; t++)
            {
                float speedX = Main.rand.Next(-10, 10);
                float speedY = Main.rand.Next(-5, 5) + Projectile.velocity.Y * 0.5f;
                Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y, speedX, speedY, ProjectileID.WoodenArrowFriendly, 28, 1f, Projectile.owner);
            }
            return false;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 20f)
            {
                Projectile.netUpdate = true;
                Projectile.ai[0] = 19f;

                Projectile.velocity.Y += 0.2f;
                if (Projectile.velocity.Y == 15f)
                {
                    Projectile.velocity.Y = 15f;
                }
            }
        }
        
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                float speedX = Main.rand.Next(-10, 10);
                float speedY = Main.rand.Next(-10, 10);
                Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y + 10, speedX, speedY, ProjectileID.WoodenArrowFriendly, 28, 1f, Projectile.owner);
            }
        }
    }
}