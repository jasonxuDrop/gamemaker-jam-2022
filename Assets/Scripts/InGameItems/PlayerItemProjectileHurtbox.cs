using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemProjectileHurtbox : MonoBehaviour
{
	public PlayerItemProjectile projectileManager;

	private void OnTriggerEnter(Collider other)
	{
		// bad practice to get component on collision
		PlayerItemProjectileEnviormentHitbox hitbox = other.GetComponent<PlayerItemProjectileEnviormentHitbox>();
		Enemy enemy = other.GetComponent<Enemy>();
		if (!hitbox && enemy)
		{
			Debug.Log($"bullet hit ENEMY named {other.name}");
			projectileManager.HitEnemy(enemy);
		}
	}
}
