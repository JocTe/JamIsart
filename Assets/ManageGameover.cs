using System.Collections;
using UnityEngine;

public class ManageGameover : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "GameOver");
    }

    private void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            Application.LoadLevel("MaineMenu");
        }
    }
}