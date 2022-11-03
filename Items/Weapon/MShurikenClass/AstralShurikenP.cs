using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class AstralShurikenP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 47;
            Projectile.height = 47;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 50;
        }
        public override void AI()
        {
            Projectile.rotation += 0.5f;

            if (Projectile.timeLeft < 35)
            {
                Projectile.velocity.Y *= 1.05f;
                Projectile.velocity.X *= 1.05f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 4; i++)
            {
                float speedX = Main.rand.Next(-5, 5);
                float speedY = Main.rand.Next(-20, -10);
                Projectile.NewProjectile(null, Projectile.position.X + 23, Projectile.position.Y + 23, speedX, speedY, ProjectileID.StarWrath, (int)(Projectile.damage), 0f, Projectile.owner, 0f, 0f);
            }
        }
    }
}