using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Tuxedo1Shirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingDamage += 0.06f;
        }
        public override void AddRecipes()
        {
            Recipe tux1shirtC = CreateRecipe();
            tux1shirtC.AddIngredient(ItemID.TuxedoShirt);
            tux1shirtC.AddIngredient(ItemID.TissueSample, 20);
            tux1shirtC.AddTile(TileID.Anvils);
            tux1shirtC.Register();

            Recipe tux1shirtS = CreateRecipe();
            tux1shirtS.AddIngredient(ItemID.TuxedoShirt);
            tux1shirtS.AddIngredient(ItemID.ShadowScale, 20);
            tux1shirtS.AddTile(TileID.Anvils);
            tux1shirtS.Register();
        }
    }
}