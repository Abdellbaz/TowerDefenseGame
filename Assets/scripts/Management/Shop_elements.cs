using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_elements : MonoBehaviour {

    public int currency = 40;
    public GameObject soldier, tank;
    public Text dollarUI;

    GameObject tower_category;

	// Use this for initialization
	void Start () {
        tower_category = GameObject.FindGameObjectWithTag("Tower_category");
	}

    bool hold;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1) && currency >= 20 && !hold)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = (GameObject)Instantiate(soldier, pos, Quaternion.identity, tower_category.transform);
            currency -= 20;
            hold = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currency >= 60 && !hold)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = (GameObject)Instantiate(tank, pos, Quaternion.identity, tower_category.transform);
            currency -= 60;
            hold = true;
        }

        if(Input.GetMouseButton(0))
        {
            hold = false;
        }

        print("money: " + currency);

        dollarUI.text = "$" + currency;

	}
}
