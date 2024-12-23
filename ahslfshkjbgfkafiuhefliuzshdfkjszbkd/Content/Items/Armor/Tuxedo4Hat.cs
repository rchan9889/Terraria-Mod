using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Tuxedo4Hat : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 6);
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 8;
            PlayerValues.gamblingDamage += 0.06f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Tuxedo4Shirt>() && legs.type == ModContent.ItemType<Tuxedo4Pants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            PlayerValues.isGamblingSet = true;
            PlayerValues.statGamble = true;
            Lighting.AddLight(player.position, TorchID.White);
            player.setBonus = "\nDefense is now randomized.\nEvery thirty seconds, grant a random buff or nerf to damage, critical hit chance, and defense.\nPlayer may sacrifice 50 hp to instantly reroll stat changes. (Default key 'Z')";
        }
        public override void AddRecipes()
        {
            Recipe tux4hat = CreateRecipe();
            tux4hat.AddIngredient(ModContent.ItemType<Armor.Tuxedo3Hat>());
            tux4hat.AddIngredient(ItemID.SoulofLight, 5);
            tux4hat.AddIngredient(ItemID.ShroomiteBar, 12);
            tux4hat.AddTile(TileID.MythrilAnvil);
            tux4hat.Register();
        }
    }
}