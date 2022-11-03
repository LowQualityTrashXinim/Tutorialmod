using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon
{
    public class SoundBlastP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 50;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("die").Type, 100000);
        }

        public override void AI()
        {
            Projectile.velocity.Y -= 0.1f;
            if (Projectile.timeLeft != 0)
            {
                Projectile.alpha += 7;
            }
        }

    }
}