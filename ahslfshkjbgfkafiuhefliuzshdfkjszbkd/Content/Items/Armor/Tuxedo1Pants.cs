using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Tuxedo1Pants : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            Recipe tux1pantsC = CreateRecipe();
            tux1pantsC.AddIngredient(ItemID.TuxedoPants);
            tux1pantsC.AddIngredient(ItemID.TissueSample, 15);
            tux1pantsC.AddTile(TileID.Anvils);
            tux1pantsC.Register();

            Recipe tux1pantsS = CreateRecipe();
            tux1pantsS.AddIngredient(ItemID.TuxedoPants);
            tux1pantsS.AddIngredient(ItemID.ShadowScale, 15);
            tux1pantsS.AddTile(TileID.Anvils);
            tux1pantsS.Register();
        }
    }
}