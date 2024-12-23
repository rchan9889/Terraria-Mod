using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Accessories{
    public class SeersEye : ModItem{
        public override void SetStaticDefaults()
        {
            
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PlayerValues.seersEye = 1;
        }
        public override void AddRecipes()
        {
            Recipe aon = CreateRecipe();
            aon.AddIngredient(ItemID.AvengerEmblem);
            aon.AddIngredient(ItemID.SoulofLight, 15);
            aon.AddIngredient(ModContent.ItemType<Items.Accessories.GamblersRing2>());
            aon.AddTile(TileID.MythrilAnvil);
            aon.Register();
        }
    }
}