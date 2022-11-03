using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Buff
{
    public class Absorbtion : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Absorbtion");
            Description.SetDefault("Heal for 40hp/s but decrease defense by 20");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen += 50;
            npc.defense -= 20;
        }
    }
}
