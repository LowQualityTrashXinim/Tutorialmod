using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RFlamethrowerClass
{
    public class FlamethrowerP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.penetrate = 4;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 25;
            Projectile.ranged = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 6;
            target.AddBuff(BuffID.Frostburn, 600);
            target.AddBuff(Mod.Find<ModBuff>("Flame").Type, 100);
        }

        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                float speedX = Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-3f, 3f);
                float speedY = Main.rand.Next(-3, 3) + Main.rand.Next(-3, 3); // This is Vanilla code, a little more obscure.
                                                                                          // Spawn the Projectile.
                Projectile.NewProjectile(Projectile.position.X + 13, Projectile.position.Y + 13, speedX, speedY, Mod.Find<ModProjectile>("FlamethrowerDustP").Type, (int)(Projectile.damage)*0, 0f, Projectile.owner, 0f, 0f);
            }
            if (Projectile.timeLeft != 0)
            {
                Projectile.rotation += 0.1f;
                Projectile.scale -= 0.025f;
            }
        }
    }
}