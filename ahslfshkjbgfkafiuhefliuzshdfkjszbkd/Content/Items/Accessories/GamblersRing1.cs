using System;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories{
    public class GamblersRing1 : ModItem{
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
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Random rnd = new Random();
            PlayerValues.gamblingDamage += 0.1f;
            PlayerValues.gambit += 1;
        }

        public override void AddRecipes()
        {
            Recipe ring1I = CreateRecipe();
            ring1I.AddIngredient(ItemID.IronBar, 3);
            ring1I.AddIngredient(ItemID.Amber, 5);
            ring1I.AddTile(TileID.Anvils);
            ring1I.Register();

            Recipe ring1L = CreateRecipe();
            ring1L.AddIngredient(ItemID.LeadBar, 3);
            ring1L.AddIngredient(ItemID.Amber, 5);
            ring1L.AddTile(TileID.Anvils);
            ring1L.Register();
        }
    }
}