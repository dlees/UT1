using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownTileBasedMovement : MonoBehaviour {

    public float speed = 4.0f;

	public Vector3 lastPosition;
    public Vector3 positionToGetTo;

	void Start () {
        positionToGetTo = transform.position;
	}
	
	void Update () {

		if (transform.position == positionToGetTo) {
			setPositionToGetTo ();
		}
        
        transform.position = Vector3.MoveTowards(transform.position, positionToGetTo, Time.deltaTime * speed);
	}

	void setPositionToGetTo ()
	{
		if (Input.GetAxis ("Vertical") > 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.up;
			lastPosition = transform.position;

		}
		else if (Input.GetAxis ("Horizontal") > 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.right;
			lastPosition = transform.position;

		} 
		else if (Input.GetAxis ("Horizontal") < 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.left;
			lastPosition = transform.position;

		} 
		else if (Input.GetAxis ("Vertical") < 0 && transform.position == positionToGetTo) {
			positionToGetTo += Vector3.down;
			lastPosition = transform.position;

		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Equals ("Wall")) {
			Debug.Log ("collide" + lastPosition);
			positionToGetTo = lastPosition;
		}
	}
}
