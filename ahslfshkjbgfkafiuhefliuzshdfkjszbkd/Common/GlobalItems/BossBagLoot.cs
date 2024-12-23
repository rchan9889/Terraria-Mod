using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.GlobalItems
{
    public class BossBagLoot : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot){
            if(item.type == ItemID.PlanteraBossBag){
                //adds the Spore Deck to the loot table with a %12.5 drop rate
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.SporeDeck>(), 8));
            }
            if(item.type == ItemID.FairyQueenBossBag){
                //adds the Prismatic Deck to the loot table with a %20 drop rate
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.PrismaticDeck>(), 5));
            }
            if(item.type == ItemID.FishronBossBag){
                //adds the Fisherman's Lucky Ring to the loot table with a %16.667 drop rate
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Accessories.GamblersRing2>(), 6));
            }
        }
    }
}