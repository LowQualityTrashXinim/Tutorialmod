using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class DemonicShurikenLeftOverP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 70;
            Projectile.ranged = true;
        }

        public override void AI()
        {
            Projectile.rotation += 1f;
            if (Projectile.timeLeft > 25)
            { 
                if (Projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref Projectile.velocity);
                    Projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 400f;
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
                    Projectile.velocity = (4 * Projectile.velocity + move) / 3f;
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
            else
            {
                Projectile.velocity.X -= Projectile.velocity.X * 0.01f;
                Projectile.velocity.Y += 0.2f;
                if (Projectile.velocity.Y == 10f)
                {
                    Projectile.velocity.Y = 10f;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y + 7, 0, 0, Mod.Find<ModProjectile>("ShadowExplosion").Type, 10, 2f, Projectile.owner);

            if (timeLeft < 25)
            {
                int numProj = 4;
                for (int i = 0; i < numProj; i++)
                {
                    float speedX = Main.rand.Next(-3, 3) + Projectile.velocity.X;
                    float speedY = Main.rand.Next(-1, 5) + Projectile.velocity.Y;
                    Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y + 7, speedX, speedY, Mod.Find<ModProjectile>("DemonicShardP").Type, 5, 2f, Projectile.owner);
                }
            }
        }
    }
}