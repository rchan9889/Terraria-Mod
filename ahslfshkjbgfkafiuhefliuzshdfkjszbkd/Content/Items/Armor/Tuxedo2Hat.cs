using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Tuxedo2Hat : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 4);
            Item.rare = ItemRarityID.Pink;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            PlayerValues.gamblingDamage += 0.08f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Tuxedo2Shirt>() && legs.type == ModContent.ItemType<Tuxedo2Pants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            PlayerValues.gamblingCR += 12;
            PlayerValues.isGamblingSet = true;
            PlayerValues.bloodTux = true;
            player.setBonus = "\nDefense is now randomized.\nPlayer sacrifices hp to attack. Attacks heal on hit.";
        }
        public override void AddRecipes()
        {
            Recipe tux2hat = CreateRecipe();
            tux2hat.AddIngredient(ItemID.TopHat);
            tux2hat.AddIngredient(ItemID.OrangeBloodroot);
            tux2hat.AddIngredient(ItemID.DarkShard);
            tux2hat.AddIngredient(ItemID.SoulofNight, 5);
            tux2hat.AddTile(TileID.CrystalBall);
            tux2hat.Register();
        }
    }
}