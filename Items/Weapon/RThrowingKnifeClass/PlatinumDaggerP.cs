using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RThrowingKnifeClass
{
    public class PlatinumDaggerP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 39;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 150;
            Projectile.aiStyle = 2;
            Projectile.tileCollide = true;
            Projectile.ranged = true;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}