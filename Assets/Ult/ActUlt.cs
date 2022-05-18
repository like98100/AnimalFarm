using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActUlt : MonoBehaviour {
    public GameObject prefab;
    public float power_ult = 490.0f;
    public float cool_down = 5.0f;
    public float crnt_time = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject character = GameObject.FindWithTag("Player");
        if (crnt_time >= cool_down)
        {
            transform.position = character.gameObject.transform.position;
            transform.rotation = character.gameObject.transform.rotation;
        }

        if (crnt_time < cool_down) crnt_time += Time.deltaTime;
		if(Input.GetKeyDown("q") && crnt_time >= cool_down)
        {
            GameObject ult = LoadUlt();
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Vector3 dir = ray.direction.normalized;
            //ult.GetComponent<Rigidbody>().velocity = dir * power_ult;

            //ult.transform.LookAt(character.transform);
            //ult.GetComponent<Rigidbody>().AddForce(transform.forward * power_ult);
            crnt_time = 0.0f;
        }
	}
    
    GameObject LoadUlt()
    {
        prefab.transform.rotation = transform.rotation;
        var ult = GameObject.Instantiate(prefab) as GameObject;
        ult.transform.parent = transform;
        ult.transform.localPosition = Vector3.zero;
        
        ult.GetComponent<Rigidbody>().AddForce(transform.forward * power_ult);
        return ult;
    }
}
