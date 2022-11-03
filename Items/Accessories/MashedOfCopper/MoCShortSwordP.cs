using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Accessories.MashedOfCopper
{
    public class MoCShortSwordP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 22;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.aiStyle = 2;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}