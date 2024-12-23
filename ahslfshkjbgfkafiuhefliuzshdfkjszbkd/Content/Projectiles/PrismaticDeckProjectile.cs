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
	public class PrismaticDeckProjectile : ModProjectile
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
			Projectile.timeLeft = 30;
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

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, Color.White, 3f);
	    	dust.noGravity = true;
	    	dust.velocity *= 5f;
    		dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0f, 0f, 100, Color.LightYellow, 2f);
            dust.noGravity = true;
		    dust.velocity *= 3f;
		}

		public override void OnKill(int timeLeft) {
            if(Projectile.damage != 0){
                for (int i = 0; i < 30; i++) {
    				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, Color.White, 3f);
	    			dust.noGravity = true;
		    		dust.velocity *= 5f;
			    	dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, 0f, 0f, 100, Color.LightYellow, 2f);
                    dust.noGravity = true;
				    dust.velocity *= 3f;
			    }
                //create new projectile, all do the same thing, just different colors
                Vector2 launchVelocity = new Vector2(0, 0);
                Random rnd = new Random();
                int color = rnd.Next(1,7);
                if(color == 1){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticRed>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }else if(color == 2){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticYellow>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }else if(color == 3){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticGreen>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }else if(color == 4){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticCyan>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }else if(color == 5){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticBlue>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }else if(color == 6){
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.PrismaticPurple>(), Projectile.damage/2, 0, Main.myPlayer, 0, 1);
                }
            }
		}
	}
}