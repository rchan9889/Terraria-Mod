using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Tuxedo4Pants : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 6);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 7;
            player.moveSpeed += 0.1f;
            PlayerValues.gamblingDamage += 0.08f;
        }
        public override void AddRecipes()
        {
            Recipe tux4pants = CreateRecipe();
            tux4pants.AddIngredient(ModContent.ItemType<Armor.Tuxedo3Pants>());
            tux4pants.AddIngredient(ItemID.WhiteTuxedoPants);
            tux4pants.AddIngredient(ItemID.SoulofLight, 5);
            tux4pants.AddIngredient(ItemID.Ectoplasm, 9);
            tux4pants.AddTile(TileID.MythrilAnvil);
            tux4pants.Register();
        }
    }
}