using System.Collections;
using UnityEngine;

public class Menuvictory : MonoBehaviour
{
    public UILabel label;
    private int score;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            Application.LoadLevel("MaineMenu");
        }
        score = PlayerPrefs.GetInt("Score");
        string myString = score.ToString();
        label.text = myString + "/184";
    }
}