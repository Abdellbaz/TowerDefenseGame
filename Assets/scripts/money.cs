using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour {

    public int currency = 40;
    public GameObject soldier, tank;
    public Text dollarUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1) && currency >= 20)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = (GameObject)Instantiate(soldier, pos, Quaternion.identity);
            currency -= 20;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currency >= 60)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = (GameObject)Instantiate(tank, pos, Quaternion.identity);
            currency -= 60;
        }

        dollarUI.text = "$" + currency;

	}
}
