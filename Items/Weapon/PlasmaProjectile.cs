using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class PlasmaProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 3;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.ranged = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, 0, Mod.Find<ModProjectile>("OnHitRangeP").Type, (int)(Projectile.damage) * 1, 0f, Projectile.owner, 0f, 0f);
        }
    }
}