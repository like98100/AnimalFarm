using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject obj;

    public float interval = 5;
    private Vector3 destination;

    void Start()
    {
        destination = transform.Find("point").position;
        InvokeRepeating("spawn", 2, interval);
        InvokeRepeating("spawn", 2, interval);
    }

    void Update()
    {

    }

    void spawn()
    {
        GameObject zombie = Instantiate(obj) as GameObject;

        zombie.transform.localPosition = new Vector3(
            destination.x + Random.Range(-3.0f, 3.0f),
            destination.y,
            destination.z + Random.Range(3.0f, 3.0f));
    }
}
