using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedMovement = 40.0f;
<<<<<<< HEAD
    public int PlayerScore = 0;
=======
	public int PlayerScore = 0;

>>>>>>> origin/master
    private Vector3 directionMove = Vector3.zero;

    private void Start()
    {
<<<<<<< HEAD
        this.enabled = false;
=======
		if (other.tag == "Pickup1") 
		{
			PlayerScore+= 5;
			Destroy(other.gameObject);
			Debug.Log(PlayerScore);
		}
		if (other.tag == "Pickup2") 
		{
			PlayerScore+= 7;
			Destroy(other.gameObject);
			Debug.Log(PlayerScore);
		}
		if (other.tag == "Pickup3") 
		{
			PlayerScore+= 10;
			Destroy(other.gameObject);
			Debug.Log(PlayerScore);
		}

		if (other.tag == "Death")
        {
            Input.GetButtonDown("ButtonA");
            FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "Scream");
            Application.LoadLevel("GameOver");
        }
>>>>>>> origin/master
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup1")
        {
            PlayerScore += 5;
            Destroy(other.gameObject);
            Debug.Log(PlayerScore);
        }
        if (other.tag == "Pickup2")
        {
            PlayerScore += 7;
            Destroy(other.gameObject);
            Debug.Log(PlayerScore);
        }
        if (other.tag == "Pickup3")
        {
            PlayerScore += 10;
            Destroy(other.gameObject);
            Debug.Log(PlayerScore);
        }
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
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * SpeedMovement;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
            // directionMove = Vector3.left;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * SpeedMovement;
        }
        else if (Input.GetAxis("Vertical") > 0.5f)
        {
            //directionMove = Vector3.up;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * SpeedMovement;
        }
        else if (Input.GetAxis("Vertical") < -0.5f)
        {
            //directionMove = Vector3.down;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * SpeedMovement;
        }
    }


    private void Move()
    {
        ChooseDirection();
        this.gameObject.transform.Translate(directionMove * SpeedMovement * Time.deltaTime);
    }
}