using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour { 

  public Animator animator;

  float currentPosX;
  float currentPosY;
  float targetPosX;
  float targetPosY;

  public void updateAnimatorValues(Vector3 currentPos, Vector3 target) {
    
    // Set Direction value on animator left:1, right:2, down:3

    currentPosY = currentPos.y;
    currentPosX = currentPos.x;

    targetPosY = target.y;
    targetPosX = target.x;

    if (currentPosX <= targetPosX && Mathf.Approximately(currentPosY , targetPosY)) {      
      Debug.Log("Moving Right");

      animator.SetInteger("Direction", 0);

    } else if (currentPosX >= targetPosX && Mathf.Approximately(currentPosY, targetPosY)) {
      Debug.Log("Moving Left");

      animator.SetInteger("Direction", 1);
    }

    if (currentPosY < targetPosY && Mathf.Approximately(currentPosX, targetPosX)) {
      Debug.Log("Moving Up");

    } else if (currentPosY > targetPosY && Mathf.Approximately(currentPosX, targetPosX)) {
      Debug.Log("Moving Down");

      animator.SetInteger("Direction", 2);
    }
  }
}
