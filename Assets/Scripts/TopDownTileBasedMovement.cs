using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownTileBasedMovement : MonoBehaviour {

    public float speed = 4.0f;

	public Vector3 lastPosition;
    public Vector3 positionToGetTo;

	// Use this for initialization
	void Start () {
        positionToGetTo = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == positionToGetTo) {
			lastPosition = transform.position;
			setPositionToGetTo ();
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
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Equals ("Wall")) {
			positionToGetTo = lastPosition;
		}
	}
}
