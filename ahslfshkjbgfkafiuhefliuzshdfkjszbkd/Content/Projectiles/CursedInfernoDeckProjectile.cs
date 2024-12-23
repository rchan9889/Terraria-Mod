using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria.Audio;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{
    public class CursedInfernoDeckProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 0;
            Projectile.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.penetrate = -1;
            DrawOffsetX = -1;
            DrawOriginOffsetY = -7;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if(Main.expertMode){
                if(target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail){
                    modifiers.FinalDamage /= 5;
                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //burn target cursed inferno debuff
            target.AddBuff(BuffID.CursedInferno, 420);
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
        public override void AI()
        {  
            //make projectile spin
            Projectile.rotation += 1;
            
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
				Projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as transparent for about 3 frames
				Projectile.alpha = 255;

				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				Projectile.Resize(250, 250);
			}
			else {
				// Smoke and fuse dust spawn. The position is calculated to spawn the dust directly on the fuse.
				if (Main.rand.NextBool()) {
					Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1f);
					dust.scale = 0.1f + Main.rand.Next(5) * 0.1f;
					dust.fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;

					dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 1f);
					dust.scale = 1f + Main.rand.Next(5) * 0.1f;
					dust.noGravity = true;
					dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
				}
			}
        }
        public override void OnKill(int timeLeft)
        {
            if(Projectile.damage != 0){
                SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                for (int i = 0; i < 80; i++) {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 3f);
                    dust.noGravity = true;
                    dust.velocity *= 5f;
                    dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 2f);
                    dust.velocity *= 3f;
                }
            }
            Projectile.Resize(15, 15);
        }
    }
}