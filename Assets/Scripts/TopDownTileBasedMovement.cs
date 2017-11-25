using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownTileBasedMovement : MonoBehaviour {

    public float speed = 4.0f;

	public DirectionController directionController;

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
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			positionToGetTo += directionController.Direction;
		}
	}

}
