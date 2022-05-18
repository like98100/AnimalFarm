using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueNPC : MonoBehaviour {
	//private GameObject target;
	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(GameObject.FindWithTag("Player").GetComponent<UnityChanControlScriptWithRgidBody>().isinterActNPC())
			{
				Destroy(gameObject, 0.5f);
			}
		}
	}
}


//UnityChanControlScriptWithRgidBody.cs

//++ var
//	public bool interActNPC = false;

//in FixedUpdate
//	if(Input.GetKeyDown(KeyCode.F)) interActNPC = true;
//	if(Input.GetKeyUp(KeyCode.F)) interActNPC = false;

//++ func
//public bool isinterActNPC()
//    {
//        return interActNPC;
//    }
