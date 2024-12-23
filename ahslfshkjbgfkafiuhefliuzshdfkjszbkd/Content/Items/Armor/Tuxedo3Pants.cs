using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Tuxedo3Pants : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4, silver: 80);
            Item.rare = ItemRarityID.Lime;
            Item.defense = 13;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 7;
            player.moveSpeed += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe tux3pants = CreateRecipe();
            tux3pants.AddIngredient(ModContent.ItemType<Armor.Tuxedo2Pants>());
            tux3pants.AddIngredient(ItemID.SoulofFright, 5);
            tux3pants.AddIngredient(ItemID.ChlorophyteBar, 9);
            tux3pants.AddTile(TileID.MythrilAnvil);
            tux3pants.Register();
        }
    }
}