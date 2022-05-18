using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public ParticleSystem testParticle;
    private AudioSource audio;
    public AudioClip gunSound;

    // Use this for initialization
    void Start () {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.gunSound;
        this.audio.loop = false;
        this.audio.volume = 0.3f;
        this.audio.pitch = 2.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            testParticle.Play();
            this.audio.Play();
            this.audio.loop = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            testParticle.Stop();
            this.audio.loop = false;
        }
    }
}
