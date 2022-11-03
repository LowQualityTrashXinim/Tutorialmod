using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.RThrowingKnifeClass
{
    public class WoodStickP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 250;
            Projectile.aiStyle = 2;
            Projectile.tileCollide = true;
            Projectile.ranged = true;
        }
    }
}