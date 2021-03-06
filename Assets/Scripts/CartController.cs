﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{

    public Animator animator;

    float currentPosX;
    float currentPosY;
    float targetPosX;
    float targetPosY;

    public void updateAnimatorValues(Vector3 currentPos, Vector3 target)
    {

        // Set Direction value on animator left:1, right:2, down:3

        currentPosY = currentPos.y;
        currentPosX = currentPos.x;

        targetPosY = target.y;
        targetPosX = target.x;

        if (currentPosX <= targetPosX && Mathf.Approximately(currentPosY, targetPosY))
        {

            animator.SetInteger("Direction", 0);

        }
        else if (currentPosX >= targetPosX && Mathf.Approximately(currentPosY, targetPosY))
        {

            animator.SetInteger("Direction", 1);
        }

        if (currentPosY < targetPosY && Mathf.Approximately(currentPosX, targetPosX))
        {

        }
        else if (currentPosY > targetPosY && Mathf.Approximately(currentPosX, targetPosX))
        {

            animator.SetInteger("Direction", 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RailHorizontal" || other.tag == "RailVertical")
        {
            Debug.Log("Rail has entered into the rail");
            GameObject obj = other.gameObject;
            Physics2D.IgnoreCollision((obj.GetComponent<Collider2D>()), GetComponent<Collider2D>());
        }

    }
}
