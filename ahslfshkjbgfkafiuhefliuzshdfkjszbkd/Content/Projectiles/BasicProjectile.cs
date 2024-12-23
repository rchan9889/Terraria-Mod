using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Common.Players;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{

    public class BasicProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 2;
            Projectile.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 2;
            Projectile.localNPCHitCooldown = -1;
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
        public override void AI()
        {
            
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for(int i = 0; i < 10; i++){
                int dust1 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 51, 0f, 0f, 100, Color.White, 1);
            }
        }
    }
}