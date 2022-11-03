using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.PPureClass
{
    public class ToxicGasP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 105;
            Projectile.height = 105;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 150;
            Projectile.aiStyle = 0;
            Projectile.tileCollide = false;
            Projectile.alpha = 155;
        }

        public override void AI()
        {
            for (int i = 0; i < 2; i++)
                {
                    float speedX = 1* Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-360f, 360f);
                    float speedY = 1* Main.rand.Next(-360, 360) + Main.rand.Next(-360, 360); // This is Vanilla code, a little more obscure.
                                                                                                                           // Spawn the Projectile.
                    Projectile.NewProjectile(Projectile.position.X + 54, Projectile.position.Y + 54, speedX, speedY, Mod.Find<ModProjectile>("ToxicGasPsmaller").Type, (int)(Projectile.damage * 0.1f), 0f, Projectile.owner, 0f, 0f);
                }
        }
    }
}