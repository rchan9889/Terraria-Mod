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
    public class Nebula : ModProjectile
    {
        bool lunatic = false;
        bool pillar = false;
        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.knockBack = 1;
            Projectile.aiStyle = 0;
            Projectile.DamageType = ModContent.GetInstance<RandomizedDamageClass>();
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.light = 0.5f;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            DrawOffsetX = -1;
			DrawOriginOffsetY = -7;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //check for Ring of the High Roller accessory
            if(Projectile.damage != 0){
                //debuff to track targets already hit
                target.AddBuff(ModContent.BuffType<Buffs.NebulaChain>(), 10);
            }

            if(PlayerValues.bloodTux){
                Random rnd = new Random();
                int heal = rnd.Next(0, 11);
                Main.player[Projectile.owner].statLife += heal;
            }
        }
        public override void AI()
        {
            Projectile.rotation++;

            int dust1 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 72, 0f, 0f, 100, default, 1);
            Main.dust[dust1].velocity = Projectile.velocity/2;
        }
        public override void OnKill(int timeLeft)
        {   
            if(Projectile.damage != 0){
                //spawn new projectile, NebulaLightning
                Vector2 launchVelocity = new Vector2(0, 0);
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<Projectiles.NebulaLightning>(), Projectile.damage, 1, Main.myPlayer, 0, 1);

                for(int i = 0; i < 10; i++){
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 71, 0f, 0f, 100, default, 1);
                }
                for(int i = 0; i < 10; i++){
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 72, 0f, 0f, 100, default, 1);
                }
                for(int i = 0; i < 10; i++){
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width+24, Projectile.height, 73, 0f, 0f, 100, default, 1);
                }
            }
        }
    }
}