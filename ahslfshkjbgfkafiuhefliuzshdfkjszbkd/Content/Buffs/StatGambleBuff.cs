using System;
using System.Security.Cryptography.X509Certificates;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories;
using Mono.Cecil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Buffs
{
    public class StatGambleBuff : ModBuff
    {
        public static bool buffed = false;
        public static float damage, crit = 0;
        public static int defense = 0;
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[ModContent.BuffType<StatGambleBuff>()] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if(!buffed){
                Random rnd = new Random();
                damage = 0.5f * (float)((rnd.NextDouble() * 2) - 1);
                PopupText buff = new PopupText();
                Main.NewText("Damage: " + damage * 100 + "%");
                crit = rnd.Next(-25, 26);
                Main.NewText("Crit: " + crit + "%");
                defense = rnd.Next(-30, 31);
                Main.NewText("Defense: " + defense);
                buffed = true;
            }
            PlayerValues.gamblingDamage += damage;
            PlayerValues.gamblingCR += crit;
            player.statDefense += defense;
        }
    }
}