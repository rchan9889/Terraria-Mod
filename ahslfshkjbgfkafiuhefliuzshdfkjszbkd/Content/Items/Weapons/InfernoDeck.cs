using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using System.Collections.Generic;
using System.Linq;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Prefixes;
using System;
using Terraria.Utilities;
using Steamworks;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Weapons
{
    public class InfernoDeck : ModItem
    { //explodes and sets enemies on fire
        public override void SetDefaults()
        {
            Item.consumable = false;
            Item.damage = 52;
            Item.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
            Item.width = 16;
            Item.height = 22;
            Item.noUseGraphic = true;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shootSpeed = 15f;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 9, copper: 4);

            Item.shoot = ModContent.ProjectileType<Projectiles.InfernoDeckProjectile>();
        }
        public override bool? UseItem(Player player)
        {
            if(PlayerValues.bloodTux){
                player.statLife -= 5;
            }
            return true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var lineToChange = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
			if(lineToChange != null)
			{
				string[] split = lineToChange.Text.Split(' ');
				lineToChange.Text = split.First() + " gambling damage";
			}
        }
        public override void AddRecipes()
        {
            Recipe magicDeck = CreateRecipe();
            magicDeck.AddIngredient(ModContent.ItemType<MagicDeck>());
            magicDeck.AddIngredient(ItemID.LivingFireBlock, 10);
            magicDeck.AddTile(TileID.MythrilAnvil);
            magicDeck.Register();
        }
        public override bool WeaponPrefix()
        {
            return true;
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            int pre = rand.Next(1, 23);
            if(pre == 1){
                return ModContent.PrefixType<Aerodynamic>();
            }else if(pre == 2){
                return ModContent.PrefixType<Bent>();
            }else if(pre == 3){
                return ModContent.PrefixType<Fated>();
            }else if(pre == 4){
                return ModContent.PrefixType<Floppy>();
            }else if(pre == 5){
                return ModContent.PrefixType<Fortunate>();
            }else if(pre == 6){
                return ModContent.PrefixType<Risky>();
            }else if(pre == 7){
                return ModContent.PrefixType<Swift>();
            }else if(pre == 8){
                return ModContent.PrefixType<Unlucky>();
            }else{
                return -1;
            }
        }
        public override void PreReforge()
        {
            UnifiedRandom rand = new UnifiedRandom();
            ChoosePrefix(rand);
        }
    }
}