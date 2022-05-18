using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float time = 0.05f;
	
	private float timer;
    private bool buttonDown = false;
	
	void Start ()
	{
		timer = time;
        buttonDown = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buttonDown = true;
            Invoke("startFlicking", 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            buttonDown = false;
            CancelInvoke();
        }
    }

    void startFlicking()
    {
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
         while (buttonDown)
         {
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            do
            {
                timer -= Time.deltaTime;
                yield return null;
            }
            while (timer > 0);
            timer = time;

            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
            do
            {
                timer -= Time.deltaTime;
                yield return null;
            }
            while (timer > 0);
            timer = time;
        }
    }
}
