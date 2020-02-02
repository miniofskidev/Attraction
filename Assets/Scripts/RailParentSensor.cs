using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailParentSensor : MonoBehaviour
{

    private GameObject player;
    public GameObject relatedNode;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("OnTrigger from Sensor " + other.name);

        if (other.tag == "Player")
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (other.tag == "RailVertical" || other.tag == "RailHorizontal")
        {

            Debug.Log("Rail placed");
        }
    }
}
