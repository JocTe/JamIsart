using System.Collections;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float movementSpeed = 4.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "Scream");
            Application.LoadLevel("GameOver");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
    }
}