using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RFlamethrowerClass
{
    public class FlamethrowerDustP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 35;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 90);
        }

        public override void AI()
        {
            Projectile.rotation += 0.01f;
            if (Projectile.timeLeft == 30)
            {
                Projectile.velocity.X -= Projectile.velocity.X;
                Projectile.velocity.Y -= Projectile.velocity.Y;
            }
            if (Projectile.timeLeft != 0)
            {
                Projectile.scale -= 0.025f;
            }
        }

    }
}