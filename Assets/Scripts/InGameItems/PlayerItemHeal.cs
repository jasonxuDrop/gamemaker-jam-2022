using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHeal : MonoBehaviour
{
    public int healAmount = 20;
    AudioSource audioSource;
    //[SerializeField] AudioClip bottlePop;
    //[SerializeField] AudioClip healSound;

    public GameObject soundToPlay;
    public GameObject soundToPlayTwo;
    [SerializeField] ParticleSystem healingParticles;



    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HealPlayer();
        
    }

    public void HealPlayer()
    {
        Instantiate(soundToPlay, transform.position, transform.rotation);
        Instantiate(soundToPlayTwo, transform.position, transform.rotation);
        Instantiate(healingParticles, transform.position, transform.rotation);
        FindObjectOfType<PlayerHealth>().HealDamage(healAmount);
        Destroy(gameObject);
    }


}
