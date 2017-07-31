using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionControllerDirection : MonoBehaviour {

    public DirectionController direction;
    public Transform interactorTransform;
    public Renderer sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = direction.Direction + new Vector3(sprite.bounds.center.x, sprite.bounds.center.y, 0);
	}
}
