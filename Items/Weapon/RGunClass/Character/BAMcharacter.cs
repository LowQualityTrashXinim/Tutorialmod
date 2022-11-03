using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.RGunClass.Character
{
    public class BAMcharacter : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 22;
            Projectile.friendly = true;
            Projectile.ranged = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 10;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.scale -= 0.05f;
            Projectile.alpha -= 1;
        }
    }
}