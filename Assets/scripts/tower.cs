using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour {

    GameObject minion;
    public GameObject bullet;
    public float BulletSpeed = 6;
    public float FireRate = 0.5f;

    Vector2 direction;
    bool shooting = false;
    float shootingTimer;

	// Update is called once per frame
	void Update () {

        if (GetComponent<Place_Tower>().isReady)
        {

            if (minion == null)
            {
                currentMFT = 10.0f;
                currentPRGS = 0;
            }


            if ((shooting) && (minion != null))
            {
                shootingTimer += Time.deltaTime;

                direction = (minion.transform.position - transform.position);
                transform.right = direction.normalized;

                if (shootingTimer > FireRate)
                {
                    var bul = (GameObject)Instantiate(bullet, (transform.position + (((transform.forward * 3.0f)) + (transform.up * -0.2f)) + (transform.right * 2.15f)), Quaternion.identity);
                    bul.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
                    shootingTimer = 0.0f;
                }
            }

        }
    }

    float currentMFT = 10;
    int currentPRGS = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("minion") && collision.GetComponent<Minion>().magFromTarget < currentMFT && collision.GetComponent<Minion>().progress >= currentPRGS)
        {
            minion = collision.gameObject;
            shooting = true;
            currentMFT = collision.GetComponent<Minion>().magFromTarget;
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == minion)
        {
            shooting = false;
            currentMFT = 10f;
            currentPRGS = 0;
        }
    }
}
