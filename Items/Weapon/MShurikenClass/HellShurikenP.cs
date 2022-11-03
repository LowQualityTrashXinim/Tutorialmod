using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class HellShurikenP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.ranged = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("HellFury").Type, 50);
        }
        public override void AI()
        {
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }    
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                float SpeedX1 = Main.rand.Next(-5, 5);
                float SpeedY1 = Main.rand.Next(-7, 2);
                Projectile.NewProjectile(Projectile.position.X + 25, Projectile.position.Y + 25, SpeedX1, SpeedY1, ProjectileID.MolotovFire, (int)(Projectile.damage), 0, Projectile.owner);
            }
        }
    }
}