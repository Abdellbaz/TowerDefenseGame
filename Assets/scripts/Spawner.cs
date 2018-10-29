using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject minion, tower;
    Vector2 loc;

	// Use this for initialization
	void Start () {
        loc = new Vector2(minion.transform.position.x, minion.transform.position.y);
	}

    float timer;

	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            var obj = Instantiate(minion, new Vector2(loc.x, loc.y), minion.transform.rotation);
            timer = 0.0f;
        }

	}
}
