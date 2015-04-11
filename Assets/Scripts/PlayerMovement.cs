using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedMovement = 5.0f;

    private Vector3 directionMove = Vector3.zero;

    private void Start()
    {
        this.enabled = false;
    }

    private void Update()
    {
        Move();
    }

    private void ChooseDirection()
    {
        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            directionMove = Vector3.right;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
            directionMove = Vector3.left;
        }
        else if (Input.GetAxis("Vertical") > 0.5f)
        {
            directionMove = Vector3.up;
        }
        else if (Input.GetAxis("Vertical") < -0.5f)
        {
            directionMove = Vector3.down;
        }
    }

    private void Move()
    {
        ChooseDirection();
        this.gameObject.transform.Translate(directionMove * SpeedMovement * Time.deltaTime);
    }
}