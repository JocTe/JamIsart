using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    public UIProgressBar PowerBar;

    // public Slider PowerBar;
    private bool isMovePhase = false;

    public bool isInputPhase = false;

    public Transform[] Players;
    public int playerIndex;
    private int lastRandomNumber;

    public float TimerPhaseMovement = 7.0f;
    private float timerMovePhase = 0.0f;
    private float timerPower;
    public int InputToSmash = 15;
    private int inputSmash = 0;
    private bool isPlayerPhase;
    private float Animtimer = 0.0f;
    public GameObject AnouncePlayer;
    public GameObject AnounceSmash;
    public bool isAnimate;

    public GameObject Animation1;
    public GameObject Animation2;
    private float timeAnim = 0.0f;

    public GameObject Bandeau1;
    public GameObject Bandeau2;
    public GameObject Bandeau3;
    public GameObject Bandeau4;
    public GameObject Smash;

    public GameObject ButtonA;
    public GameObject ButtonAExplo;

    private void Start()
    {
        ButtonA.SetActive(true);
        isAnimate = false;
        timerMovePhase = TimerPhaseMovement;
        timerPower = TimerPhaseMovement;
        Animation1.SetActive(true);
    }

    private void OnEnable()
    {
        isPlayerPhase = true;
        isInputPhase = false;
        isMovePhase = false;
    }

    private int GetRandomPlayer(int min, int max)
    {
        int result = UnityEngine.Random.Range(min, max);

        if (result == lastRandomNumber)
        {
            return GetRandomPlayer(min, max);
        }

        lastRandomNumber = result;
        return result;
    }

    private void Update()
    {
        ButtonA.SetActive(true);
        if (Animation1 != null)
            Animation1.SetActive(true);

        if (isAnimate = true)
        {
            AnimateHUD();
        }
        else
        {
            UndoAnimateHUD();
        }
        if (isPlayerPhase == true)
        {
            playerIndex = GetRandomPlayer(1, 4);
            if (playerIndex == 1)
            {
                FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "VieuxJoueur1");
                Bandeau1.SetActive(true);
                Bandeau2.SetActive(false);
                Bandeau3.SetActive(false);
                Bandeau4.SetActive(false);
                Smash.SetActive(false);
            }
            else if (playerIndex == 2)
            {
                FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "VieuxJoueur2");
                Bandeau1.SetActive(false);
                Bandeau2.SetActive(true);
                Bandeau3.SetActive(false);
                Bandeau4.SetActive(false);
                Smash.SetActive(false);
            }
            else if (playerIndex == 3)
            {
                FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "VieuxJoueur3");
                Bandeau1.SetActive(false);
                Bandeau2.SetActive(false);
                Bandeau3.SetActive(true);
                Bandeau4.SetActive(false);
                Smash.SetActive(false);
            }
            else if (playerIndex == 4)
            {
                FindObjectOfType<AudioManager>().PlaySfx(this.gameObject, "VieuxJoueur4");
                Bandeau1.SetActive(false);
                Bandeau2.SetActive(false);
                Bandeau3.SetActive(false);
                Bandeau4.SetActive(true);
                Smash.SetActive(false);
            }
            PowerBar.value = 0;
            isInputPhase = true;
            isMovePhase = false;
            isPlayerPhase = false;
        }
        if (isInputPhase == true)
        {
            InputPhase();

            //Debug.Log("Input " + inputSmash);
        }
        else if (isMovePhase == true)
        {
            MovePhase();
        }
    }

    private void InputPhase()
    {
        if (PlayerScript != null)
            PlayerScript.enabled = false;

        if (Animation2 != null)
            Animation2.SetActive(true);
        if (Animation1 != null)
            Animation1.SetActive(false);
        AnimateHUD();
        Smash.SetActive(true);
        if (Input.GetButtonDown("ButtonA"))
        {
            ButtonAExplo.SetActive(true);
            ButtonA.SetActive(false);
            inputSmash++;
            PowerBar.value += 0.05f;
            timerPower = TimerPhaseMovement;
        }
        if (Input.GetButtonUp("ButtonA"))
        {
            ButtonA.SetActive(true);
            ButtonAExplo.SetActive(false);
        }
        if (inputSmash == InputToSmash)
        {
            isInputPhase = false;
            isMovePhase = true;
            timerMovePhase = 0.0f;
        }
    }

    private void MovePhase()
    {
        ButtonAExplo.SetActive(false);
        ButtonA.SetActive(false);
        Bandeau1.SetActive(false);
        Bandeau2.SetActive(false);
        Bandeau3.SetActive(false);
        Bandeau4.SetActive(false);
        Smash.SetActive(false);
        //PowerBar.maxValue = TimerPhaseMovement;
        if (Animation2 != null)
            Animation2.SetActive(false);

        PlayerScript.enabled = true;
        timerMovePhase += Time.deltaTime;
        PowerBarMinus();
        if (timerMovePhase >= TimerPhaseMovement)
        {
            isMovePhase = false;
            isInputPhase = false;
            isPlayerPhase = true;
            inputSmash = 0;
        }
    }

    private void AnimateHUD()
    {
        //AnouncePlayer.GetComponent<Animation>().Play();
    }

    private void UndoAnimateHUD()
    {
        AnouncePlayer.GetComponent<Animation>().Stop();
    }

    private void PowerBarMinus()
    {
        timerPower -= Time.deltaTime;
        PowerBar.numberOfSteps = 0;
        PowerBar.value = (timerPower / 10);
    }
}