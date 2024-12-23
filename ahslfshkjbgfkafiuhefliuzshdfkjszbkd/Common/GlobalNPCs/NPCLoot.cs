using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.GlobalNPCs
{
    public class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if(npc.type == NPCID.Harpy){
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Accessories.BirdsEye>(), 20, 1, 1));
            }
            if (npc.type == NPCID.Plantera) {
				/* foreach (var rule in npcLoot.Get()) {
					if (rule is DropBasedOnExpertMode dropBasedOnExpertMode && dropBasedOnExpertMode.ruleForNormalMode is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsDrop && oneFromOptionsDrop.dropIds.Contains(ItemID.VenusMagnum)) {
						var original = oneFromOptionsDrop.dropIds.ToList();
						original.Add(ModContent.ItemType<Content.Items.Weapons.SporeDeck>());
						oneFromOptionsDrop.dropIds = original.ToArray();
					}
				} */
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.SporeDeck>(), 8));
			}
            if(npc.type == NPCID.EmpressButterfly){
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Weapons.PrismaticDeck>(), 5));
            }
            if(npc.type == NPCID.DukeFishron){
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Accessories.GamblersRing2>(), 6));
            }
        }
    }
}