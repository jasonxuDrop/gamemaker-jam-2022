using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	static Transform target;

	[SerializeField] public int attackPower;
	public int maxHP;
	public float maxPersuitDistance = 15;
	public float attackDistance = 2;
	public GameObject attackHurtbox;
	public bool isDummy;

	[HideInInspector]
	public bool isFree = true;

	private int hp;
	NavMeshAgent navMeshAgent;

	private void OnCollisionEnter(Collision collision)
	{
		string collides = collision.gameObject.tag;

        switch (collides)
        {
			case "BasicEnemy":
				HitPlayer();
				break;
			default:
				break;
		}
    }


	internal void HitPlayer()
	{

		FindObjectOfType<PlayerHealth>().TakeDamage(attackPower);
		
	}



	public int HP
	{
		get { return hp; }
		set
		{
			hp = value;
			if (hp <= 0)
				Die();
		}
	}

	private void Start()
	{
		if (target == null)
		{
			target = FindObjectOfType<PlayerController>().transform;
		}
		navMeshAgent = GetComponent<NavMeshAgent>();

		attackHurtbox.SetActive(false);
		HP = maxHP;
	}

	private void Update()
	{
		if (!isFree || isDummy)
			return;

		float dist = Vector3.Distance(target.position, transform.position);
		if (dist < attackDistance)
		{
			StartCoroutine(Attack());
		}
		else if (dist < maxPersuitDistance)
		{
			StartCoroutine(Move());
		}
	}

	IEnumerator Move()
	{
		isFree = false;
		navMeshAgent.isStopped = false;
		navMeshAgent.destination = target.position;

		yield return new WaitForSeconds(0.2f);

		navMeshAgent.isStopped = true;
		isFree = true;
	}
	IEnumerator Attack()
	{
		isFree = false;
		yield return new WaitForSeconds(.3f);//windup
		attackHurtbox.SetActive(true);
		yield return new WaitForSeconds(.3f);//attack duration
		attackHurtbox.SetActive(false);
		yield return new WaitForSeconds(.8f);//cooldown
		isFree = true;
	}


	public void Damage(int amount)
	{
		HP -= amount;
	}
	


	void Die()
	{
		Destroy(gameObject);
	}
}
