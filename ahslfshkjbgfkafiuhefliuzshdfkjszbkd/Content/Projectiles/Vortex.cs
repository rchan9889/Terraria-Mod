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
	public class Vortex : ModProjectile
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

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 229, 0f, 0f, 100, default, 1f);
			dust.scale = 1f + Main.rand.Next(5) * 0.1f;
			dust.noGravity = true;
			dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
		}

		public override void OnKill(int timeLeft) {
            if(Projectile.damage != 0){
                //create 5 homing projectiles
                for (int i = -2; i < 3; i++) {
                    Vector2 launchVelocity = -Projectile.velocity/3f;
                    launchVelocity = launchVelocity.RotatedBy(MathHelper.ToRadians(30) * i);
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.VortexFrag>(), 0, Projectile.knockBack, Main.myPlayer, 0, 1);
                }
            }
            for(int i = 0; i < 10; i++){
                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 227, 0f, 0f, 100, default, 1);
                dust2.noGravity = true;
            }
			SoundEngine.PlaySound(SoundID.Item44, Projectile.position);
		}
	}
}