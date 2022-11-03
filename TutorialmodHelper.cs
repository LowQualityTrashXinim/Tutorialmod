using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace tutorialmod
{
    public class customchannel
    {
        public static float Charge = 0;
        public static float MaxCharge;
        public static bool IsAtMaxCharge => Charge == MaxCharge;

        public static void channeling(Player player, float Charge, float MaxCharge)
        {
            
            if (player.channel)
            {
                if (Charge < MaxCharge)
                {
                    Charge++;
                }
                if (Charge > MaxCharge)
                {
                    Charge = MaxCharge;
                }
            }
            if (IsAtMaxCharge)
            {
                if (!player.channel)
                {
                   
                }
            }
        }
    }
}