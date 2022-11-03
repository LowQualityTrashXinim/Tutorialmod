using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class CrimsonShurikenP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 33;
            Projectile.height = 33;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 5;
            Projectile.ranged = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("Absorbtion").Type, 60);
        }
        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction;
            /*projectile.ai[0] += 1f;
            if (projectile.ai[0] == 10f)
            {
                projectile.ai[0] = 0f;
                projectile.netUpdate = true;
                float SpeedX = projectile.velocity.X * 0.5f + Main.rand.Next(-2, 2);
                float SpeedY = projectile.velocity.Y * 0.5f + Main.rand.Next(-2, 2);
                Projectile.NewProjectile(projectile.position.X + 23, projectile.position.Y + 23, SpeedX, SpeedY,mod.ProjectileType("SporeSac") , (int)(projectile.damage), 0, projectile.owner);
                projectile.velocity.Y += 1f;
                projectile.velocity.X -= projectile.velocity.X * 0.1f;
            }*/
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
        /*public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                float SpeedX1 = Main.rand.Next(-10, 10);
                float SpeedY1 = Main.rand.Next(-2, 2);
                Projectile.NewProjectile(projectile.position.X + 23, projectile.position.Y + 23, SpeedX1, SpeedY1, mod.ProjectileType("SporeSac"), (int)(projectile.damage), 0, projectile.owner);
            }
        }*/
    }
}