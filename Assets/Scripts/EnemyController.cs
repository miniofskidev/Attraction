using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool shouldMoveHorizontally = true;

    private Rigidbody2D rigidbody;
    private float speed = 25f;
    
    private void Start() {
    
      rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        // if (Input.GetButtonDown("SliceThemInHalf")) {
        //   playerAnimation.SetBool("ShouldAttack", true);
        // } else if (Input.GetButtonUp("SliceThemInHalf")) {
        //   playerAnimation.SetBool("ShouldAttack", false);
        // }

        // playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }

    void FixedUpdate() {
      
      if (shouldMoveHorizontally) {
          
        rigidbody.velocity = new Vector2(Time.deltaTime * speed, rigidbody.velocity.y);
      }
    }

    private void OnCollisionEnter(Collision other) {
      
      string tag = other.gameObject.tag;

      if (tag == "wall" || tag == "basicCollider") {
        
        Debug.Log("Collision with wall or basicCollider");

      } else if (tag == "player") {

      }
    }    
}
