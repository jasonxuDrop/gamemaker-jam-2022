using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtbox : MonoBehaviour
{
	public Enemy enemyManager;

	private void OnTriggerEnter(Collider other)
	{
		// TODO: replace PlayerController with the script that has player's hp
		var player = other.GetComponent<PlayerController>(); 
		if (player)
			enemyManager.HitPlayer(/*player*/);
	}
}