using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{
	// This projectile demonstrates exploding tiles (like a bomb or dynamite), spawning child projectiles, and explosive visual effects.
	// TODO: This projectile does not currently damage the owner, or damage other players on the For the worthy secret seed.
	public class Stardust : ModProjectile
	{
		public override void SetDefaults() {
			// While the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 0;
            Projectile.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.light = 0.5f;
			Projectile.timeLeft = 600;
			DrawOffsetX = -1;
			DrawOriginOffsetY = -7;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(PlayerValues.bloodTux){
                Random rnd = new Random();
                int heal = rnd.Next(0, 11);
                Main.player[Projectile.owner].statLife += heal;
            }
        }
        public override void AI() {
            Projectile.rotation += 1;

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 230, 0f, 0f, 100, default, 1);
	    	dust.noGravity = true;
			dust.velocity *= 5f;
            dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 187, 0f, 0f, 100, default, 2f);
            dust.noGravity = true;
		    dust.velocity *= 3f;
		}

		public override void OnKill(int timeLeft) {
            if(Projectile.damage != 0){
                for (int i = 0; i < 80; i++) {
    				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 230, 0f, 0f, 100, default, 1);
	    			dust.noGravity = true;
		    		dust.velocity *= 5f;
			    	dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 187, 0f, 0f, 100, default, 2f);
                    dust.noGravity = true;
				    dust.velocity *= 3f;
			    }
                Vector2 launchVelocity = Projectile.velocity;
                //check if Stardust Dragon has already been summoned
                if(!Main.player[Projectile.owner].HasBuff(ModContent.BuffType<Buffs.StardustDragon>())){//if not, summon it
                    Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.StardustDragon>(), 240);
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ProjectileID.StardustDragon1, Projectile.damage/10, Projectile.knockBack, Main.myPlayer, 0, 1);
                    child.minionSlots = 0f;
                    child.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
                    child.timeLeft = 240;
                    for(int i = 0; i < 10; i++){
                        Projectile child2 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ProjectileID.StardustDragon2, Projectile.damage/10, Projectile.knockBack, Main.myPlayer, 0, 1);
                        child2.minionSlots = 0f;
                        child2.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
                        child2.timeLeft = 240;
                        Projectile child3 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ProjectileID.StardustDragon3, Projectile.damage/10, Projectile.knockBack, Main.myPlayer, 0, 1);
                        child3.minionSlots = 0f;
                        child3.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
                        child3.timeLeft = 240;
                    }
                    Projectile child4 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ProjectileID.StardustDragon4, Projectile.damage/10, Projectile.knockBack, Main.myPlayer, 0, 1);
                    child4.minionSlots = 0f;
                    child4.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
                    child4.timeLeft = 240;
                }else{ //if so, summon Stardust Cell
                    Projectile child5 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ProjectileID.StardustCellMinion, Projectile.damage/10, Projectile.knockBack, Main.myPlayer, 0, 1);
                    child5.minionSlots = 0f;
                    child5.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
                    child5.timeLeft = 120;
                }
            }
		}
	}
}