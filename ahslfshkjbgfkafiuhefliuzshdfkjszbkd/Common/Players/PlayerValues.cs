using System;
using System.IO;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players
{
    internal class PlayerValues : ModPlayer
    {
        public static  float gamblingDamage = 0f;
        public static float gamblingCR = 0f;
        public static int foresight = 0;
        public static int gambit = 0;
        public static bool allOrNothing = false;
        public static int seersEye = 0;
        public static bool isGamblingSet = false;
        public static bool bloodTux = false;
        public static bool bloodSac = false;
        public static bool statGamble = false;
        public override void PostUpdate(){
            if(statGamble && !Player.HasBuff(ModContent.BuffType<Content.Buffs.StatGambleBuff>())){
                Player.AddBuff(ModContent.BuffType<Content.Buffs.StatGambleBuff>(), 1800);
                Content.Buffs.StatGambleBuff.buffed = false;
            }
        }

        public override void ResetEffects()
        {
            isGamblingSet = false;
            allOrNothing = false;
            bloodTux = false;
            bloodSac = false;
            statGamble = false;
            seersEye = 0;
            gamblingDamage = 0f;
            gamblingCR = 0f;
            gambit = 0;
            foresight = 0;
        }
    }
}