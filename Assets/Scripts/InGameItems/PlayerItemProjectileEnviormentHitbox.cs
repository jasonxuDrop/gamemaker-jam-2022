using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemProjectileEnviormentHitbox : MonoBehaviour
{
	public PlayerItemProjectile projectileManager;

	private void OnTriggerEnter(Collider other)
	{
		PlayerItemProjectileHurtbox hurtbox = other.GetComponent<PlayerItemProjectileHurtbox>();
		Item item = other.GetComponent<Item>();
		if (!hurtbox && !item)
		{
			Debug.Log($"bullet hit {other.name}");
			projectileManager.HitWall();
		}
	}
}
