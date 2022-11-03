using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class impactProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 88;
            Projectile.height = 88;
            Projectile.friendly = true;
            Projectile.melee = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 10;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;
            Projectile.alpha = 200;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 10;
        }
    }
}