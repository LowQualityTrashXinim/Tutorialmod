using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Debuff
{
    public class HellFury : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellFury");
            Description.SetDefault("Extreme Flame");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 100;
        }
    }
}
