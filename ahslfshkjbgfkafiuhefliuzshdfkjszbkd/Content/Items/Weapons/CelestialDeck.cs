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
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles;
using UtfUnknown.Core.Probers;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Weapons
{
    public class CelestialDeck : ModItem
    { //fires one of four projectiles randomly
        public override void SetDefaults()
        {
            Item.consumable = false;
            Item.damage = 160;
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
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 10);
            Item.shoot = ModContent.ProjectileType<Projectiles.Solar>();
        }
        public override bool? UseItem(Player player)
        {
            if(PlayerValues.bloodTux){
                player.statLife -= 5;
            }

            Random rnd = new Random();
            int nssv = rnd.Next(1, 5);
            if(nssv == 1){
                Item.shoot = ModContent.ProjectileType<Projectiles.Solar>();
            }else if(nssv == 2){
                Item.shoot = ModContent.ProjectileType<Projectiles.Nebula>();
            }else if(nssv == 3){
                Item.shoot = ModContent.ProjectileType<Projectiles.Vortex>();
            }else{
                Item.shoot = ModContent.ProjectileType<Projectiles.Stardust>();
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
            magicDeck.AddIngredient(ItemID.FragmentStardust, 6);
            magicDeck.AddIngredient(ItemID.FragmentNebula, 6);
            magicDeck.AddIngredient(ItemID.FragmentSolar, 6);
            magicDeck.AddIngredient(ItemID.FragmentVortex, 6);
            magicDeck.AddTile(TileID.LunarCraftingStation);
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