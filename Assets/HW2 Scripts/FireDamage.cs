using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireDamage : MonoBehaviour {

    public Slider healthBarSlider;      //reference for slider
    private bool isGameOver = false;    //flag to see if game is over;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //check if game is over i.e., health is greater than 0
        if (isGameOver)
        {
            dummy();
        }
    }

    //Check if player enters/stays on the fire
    void OnTriggerStay(Collider other)
    {
        //if player triggers fire object and health is greater than 0
        if ((other.gameObject.tag == "Flames" || other.gameObject.tag == "Zombie") && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= .011f;  //reduce health
        }
       
        else if(healthBarSlider.value == 0)
        {
            isGameOver = true;    //set game over to true
        }

        if ((other.gameObject.tag == "Goal"))
        {
            isGameOver = true;
        }
    }
    void dummy()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < objects.Length; i++)
            Destroy(objects[i]);
        GameObject[] objects2 = GameObject.FindGameObjectsWithTag("Goal");
        for (int i = 0; i < objects2.Length; i++)
            Destroy(objects2[i]);
    }
}
