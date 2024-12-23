using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using System;
using Microsoft.Build.Evaluation;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.GlobalNPCs
{
    public class NPCImmunities : GlobalNPC
    {
        public override void SetDefaults(NPC entity)
        {
            // Sets all npcs to be vulnerable to buff
            NPCID.Sets.SpecificDebuffImmunity[entity.type][ModContent.BuffType<Content.Buffs.NebulaChain>()] = false;
        }
    }
}