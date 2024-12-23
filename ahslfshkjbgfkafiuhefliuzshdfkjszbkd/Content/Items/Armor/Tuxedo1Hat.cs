using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Tuxedo1Hat : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
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
            PlayerValues.gamblingDamage += 0.04f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Tuxedo1Shirt>() && legs.type == ModContent.ItemType<Tuxedo1Pants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            PlayerValues.gamblingCR += 10;
            PlayerValues.isGamblingSet = true;
            player.setBonus = "Defense is now randomized.";
        }
        public override void AddRecipes()
        {
            Recipe tux1hatC = CreateRecipe();
            tux1hatC.AddIngredient(ItemID.TopHat);
            tux1hatC.AddIngredient(ItemID.TissueSample, 10);
            tux1hatC.AddTile(TileID.Anvils);
            tux1hatC.Register();

            Recipe tux1hatS = CreateRecipe();
            tux1hatS.AddIngredient(ItemID.TopHat);
            tux1hatS.AddIngredient(ItemID.ShadowScale, 10);
            tux1hatS.AddTile(TileID.Anvils);
            tux1hatS.Register();
        }
    }
}