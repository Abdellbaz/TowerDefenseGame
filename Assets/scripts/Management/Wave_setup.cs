using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_setup : MonoBehaviour {

    Wave_system ws;
    public GameObject circling;

	// Use this for initialization
	void Start () {
        ws = new Wave_system(5, circling, 7, 2.0f);
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.O))
        {
            ws.ready = true;
            ws.nextWave();
        }
	}
}
