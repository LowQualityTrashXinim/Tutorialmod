using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class ElementalShurikenP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 37;
            Projectile.height = 37;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 50;
            Projectile.ranged = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.immune[Projectile.owner] = 2;

            int type = Main.rand.Next(new int[] { (Mod.Find<ModProjectile>("SnowflakeP").Type),(Mod.Find<ModProjectile>("CrimsonShurikenP").Type), (Mod.Find<ModProjectile>("DemonicShurikenP").Type), (Mod.Find<ModProjectile>("DemonicShurikenP2").Type), (Mod.Find<ModProjectile>("HellShurikenP").Type), (Mod.Find<ModProjectile>("JungleShurikenP").Type) });
            Vector2 StarPosition = Projectile.position;
            StarPosition.Y -= 650;
            StarPosition.X += Main.rand.Next(-200, 200);

            Vector2 DistanceFromProjToMouse = Projectile.position - StarPosition;
            Vector2 DirectionFromProjToMouse = DistanceFromProjToMouse.SafeNormalize(Vector2.UnitX);

            Vector2 NewVelocity = DirectionFromProjToMouse * 20f;

            Projectile.NewProjectile(StarPosition.X + 14, StarPosition.Y + 14, NewVelocity.X, NewVelocity.Y, type, (int)(Projectile.damage), 0f, Projectile.owner, 0f, 0f);
        }

        public override void AI()
        {            
            Projectile.scale += 0.03f;
            Projectile.rotation += 0.4f * (float)Projectile.direction;
            Projectile.ai[0] += 1f;

            if (Projectile.ai[0] == 5f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;

                float SpeedX = Projectile.velocity.X * 0.5f + Main.rand.Next(-2, 2);
                float SpeedY = Projectile.velocity.Y * 0.5f + Main.rand.Next(-2, 2);

                int type2 = Main.rand.Next(new int[] { ProjectileID.Blizzard,ProjectileID.MolotovFire, (Mod.Find<ModProjectile>("DemonicShurikenLeftOverP").Type), (Mod.Find<ModProjectile>("SporeSac").Type), (Mod.Find<ModProjectile>("BubbleP").Type) });
                Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, SpeedX, SpeedY, type2, (int)(Projectile.damage), 0, Projectile.owner);
            }

        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                float speedX1 = Main.rand.Next(-10, 10);
                float speedY1 = Main.rand.Next(-10, 10);
                Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX1, speedY1, Mod.Find<ModProjectile>("CrimsonShurikenP").Type, (int)(Projectile.damage), 0, Projectile.owner);
                float speedX2 = Main.rand.Next(-10, 10);
                float speedY2 = Main.rand.Next(-10, 10);
                int RandomNumber = Main.rand.Next(1, 5);
                if (RandomNumber == 3 || RandomNumber == 2)
                {
                    Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX2, speedY2, Mod.Find<ModProjectile>("DemonicShurikenP").Type, (int)(Projectile.damage), 0, Projectile.owner);
                }
                else 
                {
                    Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX2, speedY2, Mod.Find<ModProjectile>("DemonicShurikenP2").Type, (int)(Projectile.damage), 0, Projectile.owner);
                }
                float speedX5 = Main.rand.Next(-10, 10);
                float speedY5 = Main.rand.Next(-10, 10);
                Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX5, speedY5, Mod.Find<ModProjectile>("HellShurikenP").Type, (int)(Projectile.damage), 0, Projectile.owner);
                float speedX6 = Main.rand.Next(-10, 10);
                float speedY6 = Main.rand.Next(-10, 10);
                Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX6, speedY6, Mod.Find<ModProjectile>("JungleShurikenP").Type, (int)(Projectile.damage), 0, Projectile.owner);
                float speedX7 = Main.rand.Next(-10, 10);
                float speedY7 = Main.rand.Next(-10, 10);
                Projectile.NewProjectile(Projectile.position.X + 19, Projectile.position.Y + 19, speedX7, speedY7, Mod.Find<ModProjectile>("SnowflakeP").Type, (int)(Projectile.damage), 0, Projectile.owner);
            }
        }
    }
}