using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    public GameObject cart;
    private CartController cartController;

    Node[] nodes;

    public float speed = 4f;
    private int nodeIndex = 0;
    float timer;

    static Vector2 currentPosHolder;

    // Start is called before the first frame update
    void Start()
    {
        nodes = GetComponentsInChildren<Node>();

        cartController = cart.GetComponent<CartController>();

        checkNode();
    }

    bool checkNode()
    {
        timer = 0;
        int tempInx = nodeIndex + 1;
        if (nodes[tempInx].GetComponent<Node>().isEnable)
        {
            currentPosHolder = nodes[nodeIndex].transform.position;
            Debug.Log(nodes[nodeIndex].enabled + " : " + nodeIndex);
            return true;
        }
        return false;
    }

    void Update()
    {
        timer = Time.deltaTime * speed;
        cartController.updateAnimatorValues(cart.transform.position, currentPosHolder);


        if (new Vector2(cart.transform.position.x, cart.transform.position.y)
                != currentPosHolder)
        {
            cart.transform.position = Vector3.Lerp(cart.transform.position, currentPosHolder, timer);
        }
        else if (nodes[nodeIndex].enabled == true)
        {
            if (nodeIndex < nodes.Length - 1)
            {
                if (checkNode() == true)
                    nodeIndex++;
            }
        }
    }
}
