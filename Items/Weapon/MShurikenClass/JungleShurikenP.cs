using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class JungleShurikenP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 45;
            Projectile.height = 45;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.ranged = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("JungleWrath").Type, 300);
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                float SpeedX = Projectile.velocity.X * 0.5f + Main.rand.Next(-2, 2);
                float SpeedY = Projectile.velocity.Y * 0.5f + Main.rand.Next(-2, 2);
                Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, SpeedX, SpeedY,Mod.Find<ModProjectile>("SporeSac").Type , (int)(Projectile.damage*.2), 0, Projectile.owner);
                Projectile.velocity.Y += 1f;
                Projectile.velocity.X -= Projectile.velocity.X * 0.1f;
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }    
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                float SpeedX1 = Main.rand.Next(-10, 10);
                float SpeedY1 = Main.rand.Next(-2, 2);
                Projectile.NewProjectile(Projectile.position.X + 23, Projectile.position.Y + 23, SpeedX1, SpeedY1, Mod.Find<ModProjectile>("SporeSac").Type, (int)(Projectile.damage*.2), 0, Projectile.owner);
            }
        }
    }
}