using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownTileBasedMovement : MonoBehaviour {

    public float speed = 4.0f;

	public Vector3 lastPosition;
    public Vector3 positionToGetTo;

    private CollisionDetector collisionDetector;

	void Start () {
        positionToGetTo = transform.position;

        collisionDetector = gameObject.GetComponentInChildren<CollisionDetector>();
	}
	
	void Update () {
        
        if (transform.position == positionToGetTo)
        {
            if (!collisionDetector.IsColliding)
            {
                setPositionToGetTo();
            }
		}
        
        transform.position = Vector3.MoveTowards(transform.position, positionToGetTo, Time.deltaTime * speed);
	}

	void setPositionToGetTo ()
	{
		if (Input.GetAxis ("Vertical") > 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.up;
		}
		else if (Input.GetAxis ("Horizontal") > 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.right;
		} 
		else if (Input.GetAxis ("Horizontal") < 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.left;
		} 
		else if (Input.GetAxis ("Vertical") < 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.down;
        }
        lastPosition = transform.position;
	}

}
