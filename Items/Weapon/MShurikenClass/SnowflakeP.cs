using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tutorialmod.Items.Weapon.MShurikenClass
{
    public class SnowflakeP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 37;
            Projectile.height = 37;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Ranged;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            EntitySource_ItemUse source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] == 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                float SpeedX = Projectile.velocity.X + Main.rand.Next(-2, 2);
                float SpeedY = Projectile.velocity.Y + Main.rand.Next(-2, 2);
                Projectile.NewProjectile(source,Projectile.position.X + 18, Projectile.position.Y +18, SpeedX, SpeedY, ProjectileID.Blizzard, (int)(Projectile.damage*.5), 0, Projectile.owner);
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
            Player player = Main.player[Projectile.owner];
            EntitySource_ItemUse source = new EntitySource_ItemUse(player, new Item(ModContent.ItemType<Snowflake>()));
            for (int i = 0; i < 5; i++)
            {
                float SpeedX1 = -Projectile.velocity.X + Main.rand.Next(-4, 4);
                float SpeedY1 = -Projectile.velocity.Y + Main.rand.Next(-4, 4);
                Projectile.NewProjectile(source, Projectile.position.X + 18, Projectile.position.Y + 18, SpeedX1 * 0.75f, SpeedY1 * 0.75f, ProjectileID.Blizzard, (int)(Projectile.damage*.5), 0, Projectile.owner);
            }
        }
    }
}