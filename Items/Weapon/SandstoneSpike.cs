using Microsoft.Xna.Framework;

using System.Collections.Generic;

using Terraria;
using Terraria.ModLoader;

using Terraria.ID;

namespace Tutorialmod.Items.Weapon
{
    public class SandstoneSpike : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.DontAttachHideToAlpha[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 154;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 90;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.hide = true;
        }


        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCsAndTiles.Add(index);
        }

        public override void AI()
        {
            if (Projectile.velocity.Y >= 5f)
            {
                Projectile.velocity.Y = 5f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 3)
            {
                Projectile.netUpdate = true;
                Projectile.ai[0] = 0f;
                Projectile.velocity -= Projectile.velocity * 0.4f;
            }
        }
        
        //public override void Kill(int timeLeft) // remember to research about adding dust here
        //{
        //    for (int i = 0; i < 25; i++)
        //    {
        //        float speedX = Main.rand.Next(-10, 10);
        //        float speedY = Main.rand.Next(-10, 10);
        //        Projectile.NewProjectile(projectile.position.X + 10, projectile.position.Y + 10, speedX, speedY, ProjectileID.WoodenArrowFriendly, 28, 1f, projectile.owner);
        //    }
        //}
    }
}