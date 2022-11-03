using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Buff
{
    public class Rage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rage");
            Description.SetDefault("Grants 50% speed, 35% crit and 20hp/s, that is if you keep fighting ");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 35;
            player.meleeSpeed *= 1.5f;
            player.lifeRegen += 20;
        }
    }
}
