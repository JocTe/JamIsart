using System.Collections;
using UnityEngine;

public class ManageMainMenu : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            Application.LoadLevel("Level1");
        }
    }
}