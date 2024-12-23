using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses
{
	public class RandomizedDamageClass : DamageClass
	{
        // This is an example damage class designed to demonstrate all the current functionality of the feature and explain how to create one of your own, should you need one.
        // For information about how to apply stat bonuses to specific damage classes, please instead refer to ExampleMod/Content/Items/Accessories/ExampleStatBonusAccessory.

        public override void SetDefaultStats(Player player) {
			// This method lets you set default statistical modifiers for your example damage class.
			// Here, we'll make our example damage class have more critical strike chance and armor penetration than normal.
            Random rnd = new Random();
            if(PlayerValues.isGamblingSet){
                if(PlayerValues.allOrNothing){
                    int aon = rnd.Next(0,2);
                    if(aon == 1){
                        player.statDefense = player.statDefense * 2;
                    }else{
                        player.statDefense *= 0;
                    }
                }else if(PlayerValues.seersEye == 1){
                    player.statDefense *= 1.5f;
                }else{
                    player.statDefense = player.statDefense * (float)(rnd.NextDouble() * 2);
                }
            }
            player.GetCritChance<RangedDamageClass>() = 0;
            player.GetCritChance<MeleeDamageClass>() = 0;
            player.GetCritChance<MagicDamageClass>() = 0;
            float playercr = player.GetCritChance<GenericDamageClass>() + PlayerValues.gamblingCR;
            if(PlayerValues.allOrNothing){
                int aon = rnd.Next(0, 2);
                if(aon == 1){
                    player.GetDamage<RandomizedDamageClass>() += PlayerValues.gamblingDamage * (2 + 2 * PlayerValues.gambit);
                    player.GetCritChance<RandomizedDamageClass>() = 100;
                }else{
                    player.GetDamage<RandomizedDamageClass>() *= 0;
                    player.GetCritChance<RandomizedDamageClass>() = 0;
                }
                /* player.GetDamage<RandomizedDamageClass>() += PlayerValues.gamblingDamage * rnd.Next(0, 2) * (2 + 2 * PlayerValues.gambit);
                player.GetCritChance<RandomizedDamageClass>() = 100 * rnd.Next(0, 2); */
            }else{
                player.GetDamage<RandomizedDamageClass>() += PlayerValues.gamblingDamage * ((float)(rnd.NextDouble()
                    * (2 + 2 * PlayerValues.gambit - (-1 - PlayerValues.gambit + PlayerValues.foresight)) 
                    - 1 - PlayerValues.gambit + PlayerValues.foresight + PlayerValues.seersEye 
                    * (-1 - PlayerValues.gambit + PlayerValues.foresight)));
                player.GetCritChance<RandomizedDamageClass>() += playercr * ((float)(rnd.NextDouble()
                    * (2 + 2 * PlayerValues.gambit - (-1 - PlayerValues.gambit + PlayerValues.foresight
                    + PlayerValues.seersEye * (-1 - PlayerValues.gambit + PlayerValues.foresight))) 
                    - 1 - PlayerValues.gambit + PlayerValues.foresight + PlayerValues.seersEye 
                    * (-1 - PlayerValues.gambit + PlayerValues.foresight)));
                if(player.GetCritChance<RandomizedDamageClass>() < 1){
                    player.GetCritChance<RandomizedDamageClass>() = 1;
                }
            }
			// These sorts of modifiers also exist for damage (GetDamage), knockback (GetKnockback), and attack speed (GetAttackSpeed).
			// You'll see these used all around in reference to vanilla classes and our example class here. Familiarize yourself with them.
		}
       
		// This property lets you decide whether or not your damage class can use standard critical strike calculations.
		// Note that setting it to false will also prevent the critical strike chance tooltip line from being shown.
		// This prevention will overrule anything set by ShowStatTooltipLine, so be careful!
		public override bool UseStandardCritCalcs => true;

		public override bool ShowStatTooltipLine(Player player, string lineName) {
			// This method lets you prevent certain common statistical tooltip lines from appearing on items associated with this DamageClass.
			// The four line names you can use are "Damage", "CritChance", "Speed", and "Knockback". All four cases default to true, and thus will be shown. For example...
            return true;
			// PLEASE BE AWARE that this hook will NOT be here forever; only until an upcoming revamp to tooltips as a whole comes around.
			// Once this happens, a better, more versatile explanation of how to pull this off will be showcased, and this hook will be removed.
		}
	}
}