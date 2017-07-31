using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour {

    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
    }

	void Update () {

        if (Input.GetAxis("Vertical") > 0)
        {
            direction = Vector3.up;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = Vector3.right;
        }
        else if (Input.GetAxis("Horizontal") < 0 )
        {
            direction = Vector3.left;
        }
        else if (Input.GetAxis("Vertical") < 0 )
        {
            direction = Vector3.down;
        }

	}
}
