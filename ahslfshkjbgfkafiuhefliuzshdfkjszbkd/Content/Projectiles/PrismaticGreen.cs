using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.DamageClasses;
using System;
using Microsoft.Build.Evaluation;

namespace ahslfshkjbgfkafiuhefliuzshdfkjszbkd.Content.Projectiles
{
	// This Example show how to implement simple homing projectile
	// Can be tested with ExampleCustomAmmoGun
	public class PrismaticGreen : ModProjectile
	{
        bool found = false;
		public override void SetStaticDefaults() {
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}
        int slow = 0;
		// Setting the default parameters of the projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults() {
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = ModContent.GetInstance<RandomizedDamageClass>(); // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.light = 0.5f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 180; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = -1;
            Projectile.extraUpdates = 100;
			Projectile.usesLocalNPCImmunity = true;
    	}
        // Custom AI
        public override void AI() {
    		float maxDetectRadius = 600f; // The maximum radius at which a projectile can detect a target
	    	float projSpeed = 5f; // The speed at which the projectile moves towards the target
	    	// Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if(!found){
		        if (closestNPC == null)
			        return;
                // If found, change the velocity of the projectile and turn it in the direction of the target
	        	// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
	        	Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
		        Projectile.rotation = Projectile.velocity.ToRotation();
                found = true;
                SoundEngine.PlaySound(SoundID.Item72, Projectile.position);
            }
            int dust1 = Dust.NewDust(Projectile.Center, 1, 1, DustID.GreenTorch, 0f, 0f, 100, default, 1);
            Main.dust[dust1].noGravity = true;
            Main.dust[dust1].velocity = new Vector2(0, 0);
            Main.dust[dust1].scale = (float)Main.rand.Next(100, 135) * 0.013f;
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs
			foreach (var target in Main.ActiveNPCs) {
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy()) {
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}
			return closestNPC;
		}
        public override void OnKill(int timeLeft)
        {
            found = false;
        }
	}
}