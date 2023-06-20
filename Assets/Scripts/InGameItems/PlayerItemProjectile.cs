using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemProjectile : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    public Transform projectileTransform;
    public GameObject attackSound;


    private void Start()
    {
        ShootAudio();
    }
    void FixedUpdate()
    {
        projectileTransform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    internal void HitWall()
    {
        Destroy(gameObject);
    }

	public void HitEnemy(Enemy enemy)
	{
        enemy.Damage(damage);
        Destroy(gameObject);
	}
    
    void ShootAudio()
    {
        Instantiate(attackSound, transform.position, transform.rotation);

    }
}
