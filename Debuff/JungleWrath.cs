using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Debuff
{
    public class JungleWrath : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Wrath");
            Description.SetDefault("Losing life");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 20;
        }
    }
}
