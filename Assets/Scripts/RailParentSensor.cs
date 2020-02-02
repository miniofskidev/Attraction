﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailParentSensor : MonoBehaviour
{

    private GameObject player;
    public bool hasRail = false;
    public GameObject relatedNode;
    private void Awake()
    {
        relatedNode.GetComponent<Node>().isEnable = false;

    }
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
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "RailHorizontal")
        {
            // Debug.Log("Rail placed");
            hasRail = true;
            relatedNode.GetComponent<Node>().isEnable = true;
        }
    }
}
