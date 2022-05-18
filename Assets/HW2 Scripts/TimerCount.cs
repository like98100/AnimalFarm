using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour {

    private Text timerText;
    private float time;
    private int currentTime;
    public static bool stop = false;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text> ();
    }
	
	// Update is called once per frame
	void Update () {
        if (stop)
        {
            time += Time.deltaTime;
            currentTime = (int)time;
            timerText.text = "Timer :" + currentTime;
        }
    }
}
