using UnityEngine;
using System.Collections;

public class ManageMainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            Application.LoadLevel("Level1");
        }
    }
}