using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RFlamethrowerClass
{
    public class SnowstormP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 21;
            Projectile.height = 21;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 30;
            Projectile.ranged = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 600);
        }

        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                float speedX = Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-2f, 2f);
                float speedY = Main.rand.Next(-2, 2) + Main.rand.Next(-2, 2); // This is Vanilla code, a little more obscure.
                                                                                          // Spawn the Projectile.
                Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y + 10, speedX, speedY, Mod.Find<ModProjectile>("SnowstormDustP").Type, 1, 0f, Projectile.owner, 0f, 0f);
            }
            if (Projectile.timeLeft != 0)
            {
                Projectile.rotation += 0.4f * (float)Projectile.direction;
                Projectile.scale -= 0.05f;
            }
        }

        public override void Kill(int timeLeft)
        {
            {
                for (int i = 0; i < 10; i++)
                {
                    float speedX = Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-5f, 5f);
                    float speedY = Main.rand.Next(-5, 5) + Main.rand.Next(-5, 5); // This is Vanilla code, a little more obscure.
                                                                                      // Spawn the Projectile.
                    Projectile.NewProjectile(Projectile.position.X + 10, Projectile.position.Y + 10, speedX, speedY, Mod.Find<ModProjectile>("SnowstormDustP").Type, 1, 0f, Projectile.owner, 0f, 0f);
                }
            }
        }
    }
}