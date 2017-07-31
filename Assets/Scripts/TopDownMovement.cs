using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour {

    public float speed = 1.0f;

    private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += moveDirection * speed * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position -= moveDirection * speed * Time.deltaTime;
    }
}
