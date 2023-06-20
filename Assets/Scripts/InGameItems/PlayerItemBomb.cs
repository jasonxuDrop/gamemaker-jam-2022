using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerItemBomb : MonoBehaviour
{
    public int damage = 5;
    public Color glowColor = Color.red;
    public Renderer modelRenderer;
    public GameObject hurtbox;
    public float explosionDuration = 0.2f;
    public GameObject bombSetSound;
    public GameObject explosionSound;

    [SerializeField] ParticleSystem explosionParticles;

    Color originalColor;

    void Start()
    {
        modelRenderer.GetComponent<Renderer>();
        originalColor = modelRenderer.material.color;
        hurtbox.SetActive(false);

        Sequence explosionSequence = DOTween.Sequence();
		for (int i = 0; i < 2; i++)
		{
            explosionSequence.Append(modelRenderer.material.DOColor(glowColor, 0.5f));
            explosionSequence.Append(modelRenderer.material.DOColor(originalColor, 0.5f));
        }
        for (int i = 0; i < 4; i++)
        {
            explosionSequence.Append(modelRenderer.material.DOColor(glowColor, 0.125f));
            explosionSequence.Append(modelRenderer.material.DOColor(originalColor, 0.125f));
        }
        explosionSequence.Play().OnComplete(Explode);

        Instantiate(bombSetSound, transform.position, transform.rotation);

    }

    void Explode()
	{
        StartCoroutine(ExplosionTimer());
        Instantiate(explosionSound, transform.position, transform.rotation);
        Instantiate(explosionParticles, transform.position, transform.rotation);
        Debug.Log("KABOOM");
	}

    public void HitEnemy(Enemy enemy)
	{
        enemy.Damage(damage);
    }

    IEnumerator ExplosionTimer()
    {
        hurtbox.SetActive(true);
        yield return new WaitForSeconds(explosionDuration);

        hurtbox.SetActive(false);
        Destroy(gameObject);
    }
}
