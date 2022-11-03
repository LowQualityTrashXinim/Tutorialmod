using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class SandquakeP : ModProjectile
    {
        float counter = 0f;
        public override void SetDefaults()
        {
            Projectile.width = 29;
            Projectile.height = 29;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 90;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player player = Main.player[Projectile.owner];
            EntitySource_ItemUse source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
            counter += 1f;
            if (counter == 10)
            {
                Projectile.NewProjectile(source,Projectile.position.X + 14, Projectile.position.Y + 14, (Projectile.velocity.X + Main.rand.Next(-5, 5)) * .25f, (Projectile.velocity.Y + Main.rand.Next(-9, -2)) * .5f, Mod.Find<ModProjectile>("SandstoneSpike").Type, (int)(Projectile.damage * 4), 1f, Projectile.owner);
                counter = 0;
            }
            return false;
        }
        public override void AI()
        {

            Projectile.spriteDirection = Projectile.direction;
            if (Projectile.velocity.Y > 10f)
            {
                Projectile.velocity.Y = 10f;
            }
        }
    }
}