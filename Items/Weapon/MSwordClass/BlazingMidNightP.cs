using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;

namespace Tutorialmod.Items.Weapon.MSwordClass
{
    public class BlazingMidNightP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 47;
            Projectile.height = 47;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 25;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            EntitySource_ItemUse source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<BlazingMidNight>()));
            Projectile.rotation += 0.5f;
            if (Projectile.timeLeft < 10)
            {
                Projectile.velocity.Y *= 1.15f;
                Projectile.velocity.X *= 1.15f;
            }
            if (Projectile.timeLeft == 1)
            {
                for (int i = 0; i < 35; i++)
                {
                    float speedX = Main.rand.Next(-7, 7);
                    float speedY = Main.rand.Next(-15, -3);
                    Projectile.NewProjectile(source, Projectile.position.X + 23, Projectile.position.Y + 23, speedX, speedY, ModContent.ProjectileType<BladeOfStarP>(), (int)(Projectile.damage * 0.5f), 0f, Projectile.owner, 0f, 0f);
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
    }
}