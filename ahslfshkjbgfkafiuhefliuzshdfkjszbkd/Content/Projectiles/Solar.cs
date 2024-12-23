using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.BigProgressBar;
using Terraria.ID;
using Terraria.ModLoader;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{
    public class Solar : ModProjectile
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
            Projectile.light = 0.5f;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            DrawOffsetX = -1;
			DrawOriginOffsetY = -7;
            Projectile.localNPCHitCooldown = -1;
			Projectile.usesLocalNPCImmunity = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(Projectile.damage != 0){
                //set target on fire with Daybreak debuff
                target.AddBuff(BuffID.Daybreak, 5);

                //creates an explosion on the target
                Vector2 launchVelocity = new Vector2(0, 0);
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.SolarExplosion>(), Projectile.damage/2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }   

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
            Projectile.rotation++;
            
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3) {
				Projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as transparent for about 3 frames
				Projectile.alpha = 255;

				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				Projectile.Resize(150, 150);
			}else{
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 1f);
				dust.scale = 1f + Main.rand.Next(5) * 0.1f;
				dust.noGravity = true;
				dust.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
            }
        }
        public override void OnKill(int timeLeft)
        {   
            if(Projectile.damage != 0){
                SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                for (int i = 0; i < 50; i++) {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 3f);
                    dust.noGravity = true;
                    dust.velocity *= 5f;
                    dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 2f);
                    dust.velocity *= 3f;
                }
                Projectile.Resize(15, 15);
            }
        }
    }
}