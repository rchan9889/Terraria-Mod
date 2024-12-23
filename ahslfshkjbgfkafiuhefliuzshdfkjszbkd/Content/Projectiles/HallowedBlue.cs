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

    public class HallowedBlue : ModProjectile
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
            Projectile.penetrate = 3;
            Projectile.localNPCHitCooldown = -1;
            DrawOffsetX = -1;
            DrawOriginOffsetY = -7;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // heal user on hit
            Main.player[Projectile.owner].statLife += damageDone/14;

            if(PlayerValues.bloodTux){
                Random rnd = new Random();
                int heal = rnd.Next(0, 11);
                Main.player[Projectile.owner].statLife += heal;
            }
        }
        public override void AI()
        {  
            //make projectile rotate
            Projectile.rotation += 1;
            
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, Color.Blue, 2f);
	    	dust.noGravity = true;
			dust.velocity *= 5f;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for(int i = 0; i < 10; i++){
                int dust2 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 15, 0f, 0f, 100, Color.Blue, 1);
            }
        }
    }
}