using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemBombHurtbox : MonoBehaviour
{
    public PlayerItemBomb bombManager;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
		{
            bombManager.HitEnemy(enemy);
        }
    }
}
