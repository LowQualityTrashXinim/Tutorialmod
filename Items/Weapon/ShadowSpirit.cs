using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class ShadowSpirit : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 150;
            Projectile.ranged = true;
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 20f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;

                if (Projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref Projectile.velocity);
                    Projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 750f;
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
                    Projectile.velocity = (2 * Projectile.velocity + move) / 5f;
                    AdjustMagnitude(ref Projectile.velocity);
                }
                void AdjustMagnitude(ref Vector2 vector)
                {
                    float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                    if (magnitude > 60f)
                    {
                        vector *= 30f / magnitude;
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 5;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.position.X + 8, Projectile.position.Y + 8, 0, 0, Mod.Find<ModProjectile>("ShadowExplosion").Type, 1, 0, Projectile.owner);
        }
    }
}