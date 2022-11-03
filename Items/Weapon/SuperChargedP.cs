using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class SuperChargedP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.melee = true;
            Projectile.light = 1f;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 250;
        }
        public override void AI()
        {
            for (int i = 0; i < 3; i++)
            {
                float speedX = 1 * Main.rand.NextFloat(.0f, .360f) + Main.rand.NextFloat(-360f, 360f);
                float speedY = 1 * Main.rand.Next(-360, 360) + Main.rand.Next(-360, 360);
                Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, speedX, speedY, Mod.Find<ModProjectile>("UpgradeMuramasaP").Type, (int)(Projectile.damage * 1), 0f, Projectile.owner, 0f, 0f);
            }
        }
    }
}