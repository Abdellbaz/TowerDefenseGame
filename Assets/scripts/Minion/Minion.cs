using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Minion script
//Uses manually-placed waypoints to simulate pathfinding

public class Minion : MonoBehaviour {

    public float speed,health;

    internal uint progress;
    internal float magnitudeFromTarget;

    public Image HPBar;
    private GameObject GridManager;
    private Vector2[] waypointList;

    private void Awake()
    {
        speed = speed == 0 ? 85 : speed;
        health = health == 0 ? 100 : health;
        GridManager = GameObject.FindGameObjectWithTag("GridManager");
        
    }

    private void Start()
    {
        HPBar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        waypointList = GridManager.GetComponent<GridManager>().waypointList;
    }

    void FixedUpdate () {
        HPBar.fillAmount = health/100f;

        Vector2 destination = new Vector2();
        if (waypointList.Length >= progress)
        {
            destination = waypointList[progress];
        }

        float xdif = destination.x - transform.position.x;
        float ydif = destination.y - transform.position.y;

        //Ternary operators > if-statements
        xdif = xdif > 1.0f ? 1.0f : xdif;
        xdif = xdif < -1.0f ? -1.0f : xdif;
        ydif = ydif > 1.0f ? 1.0f : ydif;
        ydif = ydif < -1.0f ? -1.0f : ydif;
        
        if(xdif > -1f && xdif < 1f && ydif > -1f && ydif < 1f)
        {
            progress++;
        }

        Vector2 unitsFromTarget = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        magnitudeFromTarget = unitsFromTarget.magnitude;
        GetComponent<Rigidbody2D>().velocity = new Vector2(xdif * speed * Time.deltaTime, ydif * speed * Time.deltaTime);
	}

    //Bullet collision & death
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            health -= 20f;
        }
        else if(collision.CompareTag("tankshell"))
        {
            Destroy(collision.gameObject);
            health -= 33.4f;
        }

        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("currency").GetComponent<Shop_elements>().currency += 5;
            Destroy(gameObject);
        }

    }

}
