using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.PPureClass
{
    public class ToxicGasPsmaller : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.magic = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 20;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = true;
            Projectile.alpha = 200;
        }
    }
}