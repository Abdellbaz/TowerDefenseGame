using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {

    public float speed = 20.0f;
    float health = 100;

    private GameObject GridManager;

    public int progress = 0;
    public Vector2 posFromTarget;
    public float magFromTarget = 0;
    Vector2 movement;
    Vector2[] waypointList;

    private void Start()
    {
        GridManager = GameObject.FindGameObjectWithTag("GridManager");
        waypointList = GridManager.GetComponent<GridManager>().waypointList;
    }

    float timer;

    // Update is called once per frame
    void FixedUpdate () {

        timer += Time.deltaTime;

        Vector2 destination = new Vector2();
        if (waypointList.Length >= progress)
        {
            destination = waypointList[progress];
        }

        float xdif = destination.x - transform.position.x;
        float ydif = destination.y - transform.position.y;

        if (xdif > 0.0f && xdif > 1.0f)
        {
            xdif = 1.0f;
        }
        else if (xdif < 0.0f && xdif < -1.0f)
        {
            xdif = -1.0f;
        }

        if (ydif > 0.0f && ydif > 1.0f)
        {
            ydif = 1.0f;
        }
        else if (ydif < 0.0f && ydif < -1.0f)
        {
            ydif = -1.0f;
        }
        
        if(xdif > -1f && xdif < 1f && ydif > -1f && ydif < 1f)
        {
            progress += 1;
        }

        posFromTarget = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        magFromTarget = posFromTarget.magnitude;

        GetComponent<Rigidbody2D>().velocity = new Vector2(xdif * speed * Time.deltaTime, ydif * speed * Time.deltaTime);
	}

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
            GameObject.FindGameObjectWithTag("currency").GetComponent<money>().currency += 5;
            Destroy(gameObject);
        }
    }

}
