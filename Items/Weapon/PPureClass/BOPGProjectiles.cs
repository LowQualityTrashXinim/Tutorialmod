using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.PPureClass
{
    public class BOPGProjectiles : ModProjectile
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
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.position.X , Projectile.position.Y , 0, 0, Mod.Find<ModProjectile>("ToxicGasP").Type, (int)(Projectile.damage * 1), 0f, Projectile.owner, 0f, 0f);
        }
    }
}