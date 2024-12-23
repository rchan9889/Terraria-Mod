using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind bloodSacrifice {get; private set;}
        public static ModKeybind statGamble {get; private set;}
        public override void Load()
        {
            bloodSacrifice = KeybindLoader.RegisterKeybind(Mod, "Blood Sacrifice", "Z");
            statGamble = KeybindLoader.RegisterKeybind(Mod, "Gamble Stats", "Z");
        }
    }
}