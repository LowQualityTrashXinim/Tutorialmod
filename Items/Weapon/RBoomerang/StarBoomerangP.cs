using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace Tutorialmod.Items.Weapon.RBoomerang
{
    public class StarBoomerangP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 44;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 40;
            Projectile.DamageType = DamageClass.Ranged;
        }

        int Num1 = Main.rand.Next(20, 30);
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            EntitySource_ItemUse source = new EntitySource_ItemUse(player,new Item(ModContent.ItemType<StarBoomerang>()));
            Projectile.rotation += 0.5f;


            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= Num1)
            {
                Projectile.netUpdate = true;
                Projectile.ai[0] = 0;


                Vector2 NewPosition = Projectile.position + new Vector2(12, -230);
                Vector2 MoveToNew = Projectile.position - NewPosition;
                Vector2 SafeMoveTo = MoveToNew.SafeNormalize(Vector2.UnitX)*20f;

                float projectNum = 5;
                float rotation = MathHelper.ToRadians(30);
                for (int i = 0; i < projectNum; i++)
                {
                    Vector2 SpinPos = new Vector2(SafeMoveTo.X, SafeMoveTo.Y).RotatedBy(MathHelper.Lerp(rotation, -rotation, i/(projectNum-1)));
                    if (Projectile.velocity.X < 0)
                    {
                        Projectile.NewProjectile(source ,NewPosition.X, NewPosition.Y, SpinPos.X * 0.5f, SpinPos.Y * 0.5f, ProjectileID.StarCannonStar, (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                    }
                    if (Projectile.velocity.X > 0)
                    {
                        Projectile.NewProjectile(source, NewPosition.X, NewPosition.Y, SpinPos.X * -0.5f, SpinPos.Y * 0.5f, ProjectileID.StarCannonStar, (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
                    }
                }
            }

            if (Projectile.timeLeft < 10)
            {
                Projectile.timeLeft = 9;
                Vector2 GoBack = player.Center - Projectile.position;
                Vector2 SafeGoBack = GoBack.SafeNormalize(Vector2.UnitX);
                Projectile.velocity = SafeGoBack * 25f;

                float distance = 50;
                Vector2 newMove = player.Center - Projectile.Center;
                float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                if (distanceTo < distance)
                {
                    Projectile.Kill();
                }
            }
        }
    }
}