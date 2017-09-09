using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    private bool isColliding;

    public bool IsColliding
    {
        get { return isColliding; }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Later we might want to collide with things that aren't just walls, NPCs
        if (collider.gameObject.tag.Equals("Wall"))
        {
            isColliding = true;
        }
    }
 
    void OnTriggerExit2D(Collider2D collider)
    {
        isColliding = false;
    }
}
