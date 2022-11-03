using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SlimeBall
{
    public class smallerSlimeBallP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.timeLeft = 80;
        }
    }
}