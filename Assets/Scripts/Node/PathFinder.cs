using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    public GameObject cart;
    private CartController  cartController;

    Node[] nodes;
  
    public float speed = 4f;
    int nodeIndex = 0;
    float timer;

    static Vector2 currentPosHolder;

    // Start is called before the first frame update
    void Start() {
        
        nodes = GetComponentsInChildren<Node>();
        
        cartController = cart.GetComponent<CartController>();

        checkNode();
    }

    void checkNode() {

      timer = 0;

      currentPosHolder = nodes[nodeIndex].transform.position;
      
    }

    // Update is called once per frame
    void Update() {
        
        timer = Time.deltaTime * speed;

        Debug.Log("Update Call");

        cartController.updateAnimatorValues(cart.transform.position, currentPosHolder);   

        if (new Vector2(cart.transform.position.x, cart.transform.position.y) != currentPosHolder) {

          // I need to move the player using rigidBody move method

          cart.transform.position = Vector3.Lerp(cart.transform.position, currentPosHolder, timer);
                                       
        } else {
          
          if (nodeIndex < nodes.Length - 1) {
            
            nodeIndex++;
            checkNode();
          }
        }
    }
}
