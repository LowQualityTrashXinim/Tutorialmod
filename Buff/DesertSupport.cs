using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Buff
{
    public class DesertSupport : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DesertSupport");
            Description.SetDefault("Grants 20% minion damage and 2 extra minion slots");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage += 0.2f;
            player.maxMinions += 2;
        }
    }
}
