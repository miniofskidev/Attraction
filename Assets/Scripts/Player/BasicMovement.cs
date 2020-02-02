using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public Animator animator;  

    private Vector2 movement;

    private float movementSpeed = 5f;
    private float directionMultiplier;

    private void Update() {
      movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  
    }

    void FixedUpdate() {
            
      animator.SetFloat("Horizontal", Mathf.Abs(movement.x));
      animator.SetFloat("Vertical", movement.y);
      //animator.SetFloat("Magnitude", movement.y);

      directionMultiplier = movement.x < 0 ? -2 : 2;

      transform.localScale = new Vector2(directionMultiplier, transform.localScale.y);

      rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Triggered with " + other.name + "  " + other.GetComponent<GameObject>().Tag;);

        
    }
}
