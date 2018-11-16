using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Starts and sets up the wave-system
//Still needs much work

public class Wave_setup : MonoBehaviour {

    public GameObject circling, Squaron, Trianglon,Star,Pentagon,Hexagon,Thomas,Jew;
    private Wave_system ws;
    private int count=0;
	// Use this for initialization
	void Start () {
        ws = new Wave_system(8, circling, 11);
        ws.configureWave(1).setMinions(Squaron, new Vector2(0, 10));
        ws.configureWave(2).setMinions(Star, new Vector2(0, 10));
        ws.configureWave(3).setMinions(Pentagon, new Vector2(0, 10));
        ws.configureWave(4).setMinions(Hexagon, new Vector2(0, 10));
        ws.configureWave(5).setMinions(Thomas, new Vector2(0, 10));
        ws.configureWave(6).setMinions(Trianglon, new Vector2(0, 10));
        ws.configureWave(7).setMinions(Jew, new Vector2(0, 10));





    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.O))
        {
            ws.ready = true;
            ws.nextWave();
            count++;

        }
    
	}
}
