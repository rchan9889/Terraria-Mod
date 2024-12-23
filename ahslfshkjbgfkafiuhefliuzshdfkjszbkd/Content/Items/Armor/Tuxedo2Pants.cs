using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Tuxedo2Pants : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.Pink;
            Item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingDamage += 0.09f;
        }
        public override void AddRecipes()
        {
            Recipe tux2pants = CreateRecipe();
            tux2pants.AddIngredient(ItemID.FallenTuxedoPants);
            tux2pants.AddIngredient(ItemID.SoulofNight, 5);
            tux2pants.AddIngredient(ItemID.DarkShard, 2);
            tux2pants.AddTile(TileID.MythrilAnvil);
            tux2pants.Register();
        }
    }
}