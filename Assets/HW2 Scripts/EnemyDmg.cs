using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDmg : MonoBehaviour {

    //The box's current health point total

    public ParticleSystem testParticle;
    private AudioSource audio;
    public AudioClip hit;

    public Slider EnemyHealthBar;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.hit;
        this.audio.loop = false;
    }

    public int currentHealth = 3;

    public void Damage(int damageAmount)
   {
        EnemyHealthBar.value -= .34f;
        this.audio.Play();

        //subtract damage amount when Damage function is called

        currentHealth -= damageAmount;

        //Check if health has fallen below zero

        if (currentHealth <= 0)

        {
            this.audio.Play();
            gameObject.SetActive(false);

            Destroy(gameObject, 0);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            testParticle.Play();
        }
    }
}
