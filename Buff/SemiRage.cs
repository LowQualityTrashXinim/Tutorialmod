using Terraria;
using Terraria.ModLoader;

namespace Tutorialmod.Buff
{
    public class SemiRage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SemiRage");
            Description.SetDefault("Grants 30% melee speed, 10% crit and 10 hp/s, that is if you keep fighting");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeCrit += 10;
            player.meleeSpeed += 0.3f;
            player.lifeRegen += 10;
        }
    }
}
