using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MDiskClass
{
    public class WaterDiskP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.melee = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 90;
        }
        public override void AI()
        {
            Projectile.rotation += 0.35f * (float)Projectile.direction;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                float speedX = Main.rand.NextFloat(-2f, 2f);
                float speedY = Main.rand.NextFloat(-2f, 2f);
                Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, speedX, speedY, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner, 0f, 0f);
            }
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 3, 3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -3, 3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 3, -3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -3, -3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -4, 0, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 4, 0, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 0, 4, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 0, -4, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 3, 3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -3, 3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 3, -3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -3, -3, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, -4, 0, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 4, 0, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 0, 4, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
            Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, 0, -4, Mod.Find<ModProjectile>("BubbleP").Type, (int)(Projectile.damage), 0f, Projectile.owner);
        }
    }
}