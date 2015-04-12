using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {

	public float movementSpeed = 4.0f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.right * Time.deltaTime * movementSpeed);

	}

	void OnTriggerEnter2D(Collider2D collider)
	{

	}
}
