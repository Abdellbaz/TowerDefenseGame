using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Tower : MonoBehaviour {

    Vector3 pos;
    SpriteRenderer sprtr;
    float rgb;
    public bool isReady;

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sprtr = GetComponent<SpriteRenderer>();
        rgb = 1 / 255;
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetMouseButton(0))
        {
            sprtr.color = new Color(sprtr.color.r, sprtr.color.g, sprtr.color.b, 1);
            isReady = true;
        }

        if(!isReady)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;

            transform.position = pos;
        }

    }
}
