using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Tuxedo4Shirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 6);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 16;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 5;
            player.statLifeMax2 += 50;
            PlayerValues.gamblingDamage += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe tux4shirt = CreateRecipe();
            tux4shirt.AddIngredient(ModContent.ItemType<Armor.Tuxedo3Shirt>());
            tux4shirt.AddIngredient(ItemID.WhiteTuxedoShirt);
            tux4shirt.AddIngredient(ItemID.SoulofLight, 5);
            tux4shirt.AddIngredient(ItemID.BeetleHusk, 8);
            tux4shirt.AddTile(TileID.MythrilAnvil);
            tux4shirt.Register();
        }
    }
}