using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RFlamethrowerClass
{
    public class SnowstormDustP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 21;
            Projectile.height = 21;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 15;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
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
                Projectile.rotation += 0.4f * (float)Projectile.direction;
                Projectile.scale -= 0.05f;
            }
        }

    }
}