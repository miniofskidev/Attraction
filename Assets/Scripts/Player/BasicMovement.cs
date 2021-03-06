﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public Animator animator;

    public GameObject railVertical;
    public GameObject railHorizontal;

    private Vector2 movement;

    private float movementSpeed = 5f;
    private float directionMultiplier;

    // 0 is nothing, 1 is horzontal, 2 is vertical
    public int carriageStat = 0;

    void Update()
    {

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("FixTheDamnThing"))
        {
            
            placeItem();
        } 
        if (Input.GetButtonUp("FixTheDamnThing") || Input.GetButtonUp("PickTheDamnThing")) {

            animator.SetBool("ShouldAttack", false);
        }
    }

    void FixedUpdate()
    {

        animator.SetFloat("Horizontal", Mathf.Abs(movement.x));
        animator.SetFloat("Vertical", movement.y);

        directionMultiplier = movement.x < 0 ? -2 : 2;

        transform.localScale = new Vector2(directionMultiplier, transform.localScale.y);

        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void attack() {

      animator.SetBool("ShouldAttack", true);

      // 0 right and left, 1 bottom, 2 left, 3 top
      int status = 0;

      if (movement.y > movement.x) {

        // Vertical

        if (movement.y > 0) {

          // top          
          status = 3;
        } else if (movement.y < 0) {

          // bottom
          status = 1;
        }        
      } else {

        if (movement.x > 0) {

          // right          
          status = 0;
        } else if (movement.x < 0) {

          // left
          status = 0;
        }   
      }

      animator.SetInteger("Status" ,status);
    }

    private void placeItem()
    {

        attack();

        Debug.Log("Place Item");

        if (carriageStat == 1)
        {

            Instantiate(railHorizontal, transform.position, transform.rotation);
        }
        else if (carriageStat == 2)
        {

            Instantiate(railVertical, transform.position, transform.rotation);
        }

        carriageStat = 0;
    }

    private void pickUpItem(Collider2D other)
    {

        attack();

        // Debug.Log("Picking up " + other.name + "  " + other.tag);

        if (Input.GetButtonDown("PickTheDamnThing"))
        {

            if (carriageStat == 0)
            {

                if (other.tag == "RailVertical")
                {
                    carriageStat = 2;
                }
                else if (other.tag == "RailHorizontal")
                {
                    carriageStat = 1;
                }

                other.gameObject.GetComponent<Rail>().shouldDestroy = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        pickUpItem(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        pickUpItem(other);
    }
}
