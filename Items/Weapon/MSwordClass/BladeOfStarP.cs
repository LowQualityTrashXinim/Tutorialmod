using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class BladeOfStarP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 31;
            Projectile.height = 13;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 100;
            Projectile.aiStyle = 5;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.velocity.Y += 1f;
            if (Projectile.timeLeft < 75)
            {
                Vector2 move = Vector2.Zero;
                float distance = 250f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                    {
                        Vector2 newMove = Main.npc[k].Center - Projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    Projectile.velocity = (4 * Projectile.velocity + move) / 5f;
                    AdjustMagnitude(ref Projectile.velocity);
                }
                void AdjustMagnitude(ref Vector2 vector)
                {
                    float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                    if (magnitude > 30f)
                    {
                        vector *= 20f / magnitude;
                    }
                }
            }
            else if (Projectile.timeLeft > 30)
            {
                Projectile.velocity += Projectile.velocity * 0.05f;
            }
            Projectile.alpha += 15;
        }
    }
}