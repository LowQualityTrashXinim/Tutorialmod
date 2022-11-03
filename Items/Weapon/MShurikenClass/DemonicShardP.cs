using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class DemonicShardP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 7;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 30;
            Projectile.ranged = true;
        }

        public override void AI()
        {
            Projectile.rotation += 1f;

            Projectile.velocity.Y += 0.5f;
            if (Projectile.velocity.Y == 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.position.X + 5, Projectile.position.Y + 4, 0, 0, Mod.Find<ModProjectile>("ShadowExplosion").Type, 10, 2f, Projectile.owner);
        }
    }
}