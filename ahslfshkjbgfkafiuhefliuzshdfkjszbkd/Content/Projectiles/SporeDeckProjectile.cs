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
	public class SporeDeckProjectile : ModProjectile
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

            // 10 second fuse
			Projectile.timeLeft = 600;

			// These help the projectile hitbox be centered on the projectile sprite.
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
		}

		public override void OnKill(int timeLeft) {
			// If we are the original projectile running on the owner, spawn the 5 child projectiles.
            if(Projectile.damage != 0){
                for (int i = -2; i < 3; i++) {
                    // Random upward vector.
                    Vector2 launchVelocity = new Vector2(i, -5);
                    // Importantly, IsChild is set to true here. This is checked in OnTileCollide to prevent bouncing and here in OnKill to prevent an infinite chain of splitting projectiles.
                    Random rnd = new Random();
                    int spore = rnd.Next(1, 3);
                    if(spore == 1){
                        Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.Spore1>(), Projectile.damage/5, Projectile.knockBack, Main.myPlayer, 0, 1);
                    }else{
                        Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.Spore2>(), Projectile.damage/5, Projectile.knockBack, Main.myPlayer, 0, 1);
                    }
                    // Usually editing a projectile after NewProjectile would require sending MessageID.SyncProjectile, but IsChild only affects logic running for the owner so it is not necessary here.
                }
            }
			// Play explosion sound
			SoundEngine.PlaySound(SoundID.Item16, Projectile.position);
		}
	}
}