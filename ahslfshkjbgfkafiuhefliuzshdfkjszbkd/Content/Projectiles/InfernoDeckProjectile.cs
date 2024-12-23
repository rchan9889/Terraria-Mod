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
	public class InfernoDeckProjectile : ModProjectile
	{
		private const int ExplosionWidthHeight = 250;

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
            Projectile.penetrate = -1;

			// 5 second fuse.
			Projectile.timeLeft = 600;

			// These help the projectile hitbox be centered on the projectile sprite.
			DrawOffsetX = -1;
			DrawOriginOffsetY = -7;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
			// Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
			if (Main.expertMode) {
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail) {
					modifiers.FinalDamage /= 5;
				}
			}
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			//set target on fire
            target.AddBuff(BuffID.OnFire, 420);
            Projectile.timeLeft = 4;

			if(PlayerValues.bloodTux){
                Random rnd = new Random();
                int heal = rnd.Next(0, 11);
                Main.player[Projectile.owner].statLife += heal;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.timeLeft = 4;
            return false;
        }
        public override void AI() {
            Projectile.rotation += 1;
			
			// The projectile is in the midst of exploding during the last 3 updates.
			if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
				Projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as transparent for about 3 frames
				Projectile.alpha = 255;

				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				Projectile.Resize(ExplosionWidthHeight, ExplosionWidthHeight);
			}
			else {
				// Smoke and fuse dust spawn. The position is calculated to spawn the dust directly on the fuse.
				if (Main.rand.NextBool()) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1f);
					dust.scale = 0.1f + Main.rand.Next(5) * 0.1f;
					dust.fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;

					dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1f);
					dust.scale = 1f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
				}
			}
		}

		public override void OnKill(int timeLeft) {
			if(Projectile.damage != 0){
				SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
				for (int i = 0; i < 80; i++) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
					dust.noGravity = true;
					dust.velocity *= 5f;
					dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
					dust.velocity *= 3f;
				}
			}
			Projectile.Resize(15, 15);
		}
	}
}