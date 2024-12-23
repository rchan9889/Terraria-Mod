using System.Security.Cryptography.X509Certificates;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories{
    public class GamblerEmblem : ModItem{
        public static readonly int MultiplicativeDamage = 15;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MultiplicativeDamage);
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Random rnd = new Random();
            PlayerValues.gamblingDamage += 0.15f;
        }
    }
}