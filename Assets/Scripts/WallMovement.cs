using System.Collections;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float movementSpeed = 4.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Game");
            Application.LoadLevel("GameOver");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
    }
}