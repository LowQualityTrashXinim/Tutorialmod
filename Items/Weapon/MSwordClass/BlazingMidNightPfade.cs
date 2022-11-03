using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class BlazingMidNightPfade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 47;
            Projectile.height = 47;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.melee = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 30;
        }
        public override void AI()
        {
            Projectile.rotation += 0.5f;
            Projectile.alpha += 25;
        }
    }
}