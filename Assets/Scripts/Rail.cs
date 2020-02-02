using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{

    public bool shouldDestroy = false;

    private void Update()
    {

        if (shouldDestroy)
        {
            Destroy(this.gameObject);
        }
    }

}
