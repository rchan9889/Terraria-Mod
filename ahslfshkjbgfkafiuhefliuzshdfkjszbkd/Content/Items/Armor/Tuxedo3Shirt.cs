using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Tuxedo3Shirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4, silver: 80);
            Item.rare = ItemRarityID.Lime;
            Item.defense = 16;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 5;
            player.statLifeMax2 += 15;
        }
        public override void AddRecipes()
        {
            Recipe tux3shirt = CreateRecipe();
            tux3shirt.AddIngredient(ModContent.ItemType<Armor.Tuxedo2Shirt>());
            tux3shirt.AddIngredient(ItemID.SoulofMight, 5);
            tux3shirt.AddIngredient(ItemID.ChlorophyteBar, 12);
            tux3shirt.AddTile(TileID.MythrilAnvil);
            tux3shirt.Register();
        }
    }
}