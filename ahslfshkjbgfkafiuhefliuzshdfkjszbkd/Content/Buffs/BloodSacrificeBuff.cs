using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Mono.Cecil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Buffs
{
    public class BloodSacrificeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            
        }
        public override void Update(Player player, ref int buffIndex)
        {
            PlayerValues.gamblingDamage += 0.5f;
        }
    }
}