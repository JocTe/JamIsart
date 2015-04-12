using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedMovement = 40.0f;

    private Vector3 directionMove = Vector3.zero;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wall")
        {
            //directionMove = Vector3.zero;
        }
    }

    private void Start()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
        //directionMove = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Update()
    {
        Move();
    }

    private void ChooseDirection()
    {
        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            //directionMove = Vector3.right;
			gameObject.GetComponent<Rigidbody >().velocity = Vector3.right*SpeedMovement;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
           // directionMove = Vector3.left;
			gameObject.GetComponent<Rigidbody >().velocity = Vector3.left*SpeedMovement;
        }
        else if (Input.GetAxis("Vertical") > 0.5f)
        {
            //directionMove = Vector3.up;
			gameObject.GetComponent<Rigidbody >().velocity = Vector3.up*SpeedMovement;
        }
        else if (Input.GetAxis("Vertical") < -0.5f)
        {
            //directionMove = Vector3.down;
			gameObject.GetComponent<Rigidbody >().velocity = Vector3.down*SpeedMovement;
        }
    }

    private void Move()
    {
        ChooseDirection();
        this.gameObject.transform.Translate(directionMove * SpeedMovement * Time.deltaTime);
    }
}