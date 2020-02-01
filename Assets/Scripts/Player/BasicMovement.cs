using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    private float movementSpeed = 5f;

    void Update() {
        
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);  

      transform.position = transform.position + movement * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
      
    }
}
