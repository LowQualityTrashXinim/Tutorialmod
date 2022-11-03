using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Buff
{
    public class JungleCalm : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Calmness");
            Description.SetDefault("Grants 10% minion damage and an extra minion slot");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage += 0.1f;
            player.maxMinions ++;
        }
    }
}
