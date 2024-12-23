using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Tuxedo3Hat : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4, silver: 80);
            Item.rare = ItemRarityID.Lime;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingCR += 8;
            player.statLifeMax2 += 10;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Tuxedo3Shirt>() && legs.type == ModContent.ItemType<Tuxedo3Pants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            PlayerValues.isGamblingSet = true;
            PlayerValues.bloodSac = true;
            player.setBonus = "\nDefense is now randomized.\nPlayer may sacrifice 50 hp to deal 50% increased damage. (Default key 'Z')";
            for(int i = 0; i < 1; i++){
                Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Blood, 0f, 0f, 100, default, 1f);
            }
        }
        public override void AddRecipes()
        {
            Recipe tux3hat = CreateRecipe();
            tux3hat.AddIngredient(ModContent.ItemType<Armor.Tuxedo2Hat>());
            tux3hat.AddIngredient(ItemID.SoulofSight, 5);
            tux3hat.AddIngredient(ItemID.ChlorophyteBar, 5);
            tux3hat.AddTile(TileID.MythrilAnvil);
            tux3hat.Register();
        }
    }
}