using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MaStaffClass
{
    public class HolyStaffOrb : ModProjectile
    {
        public float counter = 0f;

        public override void SetDefaults()
        {
            Projectile.width = 41;
            Projectile.height = 41;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.magic = true;
            Projectile.light = 2f;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 900;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 2;
            counter+=1f;
            if (counter == 3f)
            {
                Vector2 MovingPosition = Projectile.position + Main.rand.NextVector2Circular(300f,300f);
                Vector2 DistanceFromProjToMoProj = Projectile.position - MovingPosition;
                Vector2 DirectionFromProjToMoProj = DistanceFromProjToMoProj.SafeNormalize(Vector2.UnitX);
                Vector2 speed = DirectionFromProjToMoProj * 5f;
                Projectile.NewProjectile(MovingPosition.X + 20, MovingPosition.Y + 20, speed.X, speed.Y, Mod.Find<ModProjectile>("SmallHolyOrb").Type, (int)(damage*0.5f), knockback, Projectile.owner);
                counter = 0f;
            }
        }
    }
}