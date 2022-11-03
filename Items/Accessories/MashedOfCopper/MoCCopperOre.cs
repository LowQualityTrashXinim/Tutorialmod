using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Accessories.MashedOfCopper
{
    public class MoCCopperOre : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = 2;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation += 0.2f * (float)Projectile.direction;

            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
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
                if (magnitude > 20f)
                {
                    vector *= 10f / magnitude;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 10; i++)
                {
                    float speedX = Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-2f, 2f);
                    float speedY = Main.rand.Next(-2, 2) + Main.rand.Next(-2, 2);
                    Projectile.NewProjectile(Projectile.position.X + 9, Projectile.position.Y + 11, speedX, speedY, Mod.Find<ModProjectile>("MoCDustP").Type, (int)(Projectile.damage) * 0, 0f, Projectile.owner, 0f, 0f);
                }
            }
        }
    }
}