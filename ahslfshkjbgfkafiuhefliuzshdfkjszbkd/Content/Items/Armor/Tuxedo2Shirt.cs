using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Tuxedo2Shirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.Pink;
            Item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingDamage += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe tux2shirt = CreateRecipe();
            tux2shirt.AddIngredient(ItemID.FallenTuxedoShirt);
            tux2shirt.AddIngredient(ItemID.SoulofNight, 5);
            tux2shirt.AddIngredient(ItemID.DarkShard, 2);
            tux2shirt.AddTile(TileID.MythrilAnvil);
            tux2shirt.Register();
        }
    }
}