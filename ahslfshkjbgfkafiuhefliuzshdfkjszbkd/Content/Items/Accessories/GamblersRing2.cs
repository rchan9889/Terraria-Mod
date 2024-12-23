using System;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories{
    public class GamblersRing2 : ModItem{
        public override void SetStaticDefaults()
        {
/*             DisplayName.SetDefault("Gambler's Ring");
            Tooltip. */
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Lime;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Random rnd = new Random();
            PlayerValues.gamblingDamage += 0.05f;
            PlayerValues.gambit += 2;
        }
    }
}