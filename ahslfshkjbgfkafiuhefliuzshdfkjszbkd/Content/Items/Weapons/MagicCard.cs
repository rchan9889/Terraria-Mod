using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using System.Collections.Generic;
using System.Linq;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Weapons{
    public class MagicCard : ModItem
    { // no longer affected by gravity
        public override void SetDefaults()
        {
            Item.maxStack = 9990;
            Item.consumable = true;
            Item.damage = 26;
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
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(copper: 26);

            Item.shoot = ModContent.ProjectileType<Projectiles.MagicCardProjectile>();
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
			Recipe magicCardRecipeCrimson = CreateRecipe(54);
            magicCardRecipeCrimson.AddIngredient(ModContent.ItemType<PlayingCard>(), 54);
            magicCardRecipeCrimson.AddIngredient(ItemID.TissueSample, 5);
			magicCardRecipeCrimson.AddIngredient(ItemID.FallenStar, 1);
			magicCardRecipeCrimson.AddTile(TileID.Anvils);
			magicCardRecipeCrimson.Register();

            Recipe magicCardRecipeCorruption = CreateRecipe(54);
            magicCardRecipeCorruption.AddIngredient(ModContent.ItemType<PlayingCard>(), 54);
            magicCardRecipeCorruption.AddIngredient(ItemID.ShadowScale, 5);
			magicCardRecipeCorruption.AddIngredient(ItemID.FallenStar, 1);
			magicCardRecipeCorruption.AddTile(TileID.Anvils);
			magicCardRecipeCorruption.Register();
		}
    }
}