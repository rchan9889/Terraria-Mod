using System;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories{
    public class ArtificialEye : ModItem{
        public override void SetStaticDefaults()
        {
            
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
            PlayerValues.foresight += 2;
        }
        public override void AddRecipes()
        {
            Recipe ring1I = CreateRecipe();
            ring1I.AddIngredient(ItemID.SoulofSight, 10);
            ring1I.AddIngredient(ItemID.EyeoftheGolem, 1);
            ring1I.AddTile(TileID.MythrilAnvil);
            ring1I.Register();
        }
    }
}