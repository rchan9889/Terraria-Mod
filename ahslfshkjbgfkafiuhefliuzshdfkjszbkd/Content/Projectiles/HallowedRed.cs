using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using Terraria.Audio;
using Microsoft.Build.Evaluation;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{

    public class HallowedRed : ModProjectile
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
            Projectile.localNPCHitCooldown = -1;
            DrawOffsetX = -1;
            DrawOriginOffsetY = -7;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if(Main.expertMode){
                if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail) {
					modifiers.FinalDamage /= 5;
				}
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
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
            Projectile.rotation += 1;
            
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, Color.Red, 2f);
			dust.noGravity = true;
            dust.velocity *= 5f;
            if(Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3){
                Projectile.tileCollide = false;
                Projectile.alpha = 255;
                Projectile.Resize(125, 125);
            }
        }
        public override void OnKill(int timeLeft)
        {
            if(Projectile.damage != 0){
                SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                    for(int i = 0; i < 80; i++){
                    Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width+24, Projectile.height, DustID.GiantCursedSkullBolt, 0f, 0f, 100, Color.Red, 1);
                    dust2.noGravity = true;
                }
            }
            Projectile.Resize(15, 15);
        }
    }
}