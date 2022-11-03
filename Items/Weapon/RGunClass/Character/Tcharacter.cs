﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.RGunClass.Character
{
    public class Tcharacter : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.ranged = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 150;
            Projectile.tileCollide = true;
            Projectile.scale = 0.1f;
        }
        public override void AI()
        {
            if (Projectile.scale < 1f)
            {
                Projectile.scale += 0.1f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.position.X + 6, Projectile.position.Y + 9, 0f, 0f, Mod.Find<ModProjectile>("BAMcharacter").Type, 0, 0, Projectile.owner);
        }
    }
}