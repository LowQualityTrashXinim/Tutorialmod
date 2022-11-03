using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class OnHitRangeP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.ranged = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 10;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            if (Projectile.timeLeft > 0)
            {
                Projectile.scale -= 0.25f; 
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 5;
        }
    }
}