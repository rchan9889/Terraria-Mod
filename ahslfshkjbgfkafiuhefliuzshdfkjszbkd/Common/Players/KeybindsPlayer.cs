using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Systems;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players
{
    public class KeybindsPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if(KeybindSystem.bloodSacrifice.JustPressed){
                if(PlayerValues.bloodSac && !Player.HasBuff(ModContent.BuffType<Content.Buffs.BloodSacrificeBuff>())){
                    Player.statLife -= 50;
                    Player.AddBuff(ModContent.BuffType<Content.Buffs.BloodSacrificeBuff>(), 1800);
                    SoundStyle bloodSacrificeSound = new SoundStyle("ahslfshkjbgfkafiuhefliuzshdfkjszbkd/Assets/Sounds/Slash");
                    SoundEngine.PlaySound(bloodSacrificeSound, Player.position);
                }
            }
            if(KeybindSystem.statGamble.JustPressed){
                if(PlayerValues.statGamble){
                    Player.statLife -= 50;
                    if(Player.HasBuff(ModContent.BuffType<Content.Buffs.StatGambleBuff>())){
                        Player.ClearBuff(ModContent.BuffType<Content.Buffs.StatGambleBuff>());
                    }
                    Player.AddBuff(ModContent.BuffType<Content.Buffs.StatGambleBuff>(), 1800);
                    Content.Buffs.StatGambleBuff.buffed = false;
                    SoundEngine.PlaySound(SoundID.NPCDeath7, Player.position);
                    SoundEngine.PlaySound(SoundID.Pixie, Player.position);
                }
            }
        }
    }
}