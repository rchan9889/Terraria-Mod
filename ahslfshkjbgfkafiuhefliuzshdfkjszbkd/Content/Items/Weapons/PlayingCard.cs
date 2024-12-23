using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using System.Collections.Generic;
using System.Linq;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Items.Weapons
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class PlayingCard : ModItem
	{ //basic thrown weapon
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ahslfshkjbgfkafiuhefliuzshdfkjszbkd.hjson' file.
		public override void SetDefaults()
		{
			Item.maxStack = 9990;
			Item.consumable = true;
			Item.damage = 13;
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
			Item.value = Item.sellPrice(copper: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.shoot = ModContent.ProjectileType<Projectiles.BasicProjectile>();

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
			Recipe playingCardRecipeC = CreateRecipe(54);
			playingCardRecipeC.AddIngredient(ItemID.Wood, 2);
			playingCardRecipeC.AddIngredient(ItemID.CopperBar, 1);
			playingCardRecipeC.AddTile(TileID.WorkBenches);
			playingCardRecipeC.Register();

			Recipe playingCardRecipeT = CreateRecipe(54);
			playingCardRecipeT.AddIngredient(ItemID.Wood, 2);
			playingCardRecipeT.AddIngredient(ItemID.TinBar, 1);
			playingCardRecipeT.AddTile(TileID.WorkBenches);
			playingCardRecipeT.Register();
		}
	}
}
