using System.Collections;
using System.Net.Mime;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel("Victory");
            PlayerPrefs.SetInt("Score", player.PlayerScore);
        }
    }
}