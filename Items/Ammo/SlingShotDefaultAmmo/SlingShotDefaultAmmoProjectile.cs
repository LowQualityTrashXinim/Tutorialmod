using Terraria;
using tutorialmod;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Tutorialmod.Items.Ammo.SlingShotDefaultAmmo
{
    public class SlingShotDefaultAmmoProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
        }
    }
}