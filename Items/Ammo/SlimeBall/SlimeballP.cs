using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SlimeBall
{
    public class SlimeballP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 27;
            Projectile.height = 27;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 35;
        }
        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 1; i++)
                {
                    int l = Main.rand.Next(1, 4);
                    if (l == 2 || l == 3)
                    {
                        float speedX = -Projectile.velocity.X * Main.rand.NextFloat(.1f, .2f) + Main.rand.NextFloat(-2f, 2f);
                        float speedY = -Projectile.velocity.Y * Main.rand.Next(10, 40) * 0.01f + Main.rand.Next(-8, 7) * 0.4f; // This is Vanilla code, a little more obscure.
                                                                                                                               // Spawn the Projectile.
                        Projectile.NewProjectile(Projectile.position.X + 13, Projectile.position.Y + 13, speedX, speedY, Mod.Find<ModProjectile>("smallerSlimeBallP").Type, (int)(Projectile.damage * 0.15), 0f, Projectile.owner, 0f, 0f);
                    }
                }
            }
        }
        public override void Kill (int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                float speedX = Projectile.velocity.X * Main.rand.NextFloat(.5f, 1.5f);
                float speedY = Main.rand.Next(10, 40) * 0.01f + Main.rand.Next(-8, 7) * 0.4f; // This is Vanilla code, a little more obscure.
                                                                                                                       // Spawn the Projectile.
                Projectile.NewProjectile(Projectile.position.X + 8, Projectile.position.Y + 8, speedX, speedY, Mod.Find<ModProjectile>("smallerSlimeBallP").Type, (int)(Projectile.damage * 0.15), 0f, Projectile.owner, 0f, 0f);
            }
        }
    }
}