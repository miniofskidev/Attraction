using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Range(0, 10)]
    public float distance = 0;
    [Tooltip("it will move vertical by default")]
    public bool moveHorizantal;
    private Vector2 startPoint;
    private Vector2 destPoint;

    void Start()
    {
        startPoint = transform.position;
        destPoint = new Vector2(transform.position.x + distance, transform.position.y + distance);
    }

    void Update()
    {
        if (moveHorizantal)
        {
            transform.position = new Vector3(
                Mathf.PingPong(Time.time * 2, destPoint.x - startPoint.x) + startPoint.x,
                transform.position.y,
                transform.position.z
                );
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x,
                Mathf.PingPong(Time.time * 2, destPoint.y - startPoint.y) + startPoint.y,
                transform.position.z
                );
        }
    }
}
