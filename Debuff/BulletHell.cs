using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Debuff
{
    public class BulletHell : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BulletHell");
            Description.SetDefault("Until you dodge all, keep em coming");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
