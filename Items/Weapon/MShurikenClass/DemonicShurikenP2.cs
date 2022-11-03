using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class DemonicShurikenP2 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 35;
            Projectile.ranged = true;
        }

        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                Projectile.velocity.Y += 1f;
                Projectile.velocity.X -= Projectile.velocity.X * .08f;
                if (Projectile.velocity.Y > 16f)
                {
                    Projectile.velocity.Y = 16f;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            int numProj = 4;
            for (int i = 0; i < numProj; i++)
            {
                float speedX = Main.rand.Next(-4, 4) + Projectile.velocity.X;
                float speedY = Main.rand.Next(-1, 3) + Projectile.velocity.Y;
                Projectile.NewProjectile(Projectile.position.X + 21, Projectile.position.Y + 21, speedX, speedY, Mod.Find<ModProjectile>("DemonicShurikenLeftOverP").Type, 12, 2f, Projectile.owner);
            }
        }
    }
}