using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement PlayerScript;

    // public Slider PowerBar;
    private bool isMovePhase = false;

    private bool isInputPhase = false;

    public Transform[] Players;
    public int playerIndex;
    private int lastRandomNumber;

    public float TimerPhaseMovement = 7.0f;
    private float timerMovePhase = 0.0f;
    private float timerPower;
    public int InputToSmash = 15;
    private int inputSmash = 0;
    private bool isPlayerPhase;

    public GameObject AnouncePlayer;
    public GameObject AnounceSmash;

    private void Start()
    {
        timerMovePhase = TimerPhaseMovement;
        timerPower = TimerPhaseMovement;
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
        if (isPlayerPhase == true)
        {
            playerIndex = GetRandomPlayer(1, 4);
            isPlayerPhase = false;
            isInputPhase = true;
            isMovePhase = false;
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
        // PowerBar.maxValue = InputToSmash;
        PlayerScript.enabled = false;
        AnimateHUD();
        if (Input.GetButtonDown("ButtonA"))
        {
            inputSmash++;
            //PowerBar.value = inputSmash;
            timerPower = TimerPhaseMovement;
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
        //PowerBar.maxValue = TimerPhaseMovement;

        PlayerScript.enabled = true;
        timerMovePhase += Time.deltaTime;
        PowerBarMinus();
        if (timerMovePhase >= TimerPhaseMovement)
        {
            isMovePhase = false;
            isInputPhase = true;
            inputSmash = 0;
        }
    }

    private void AnimateHUD()
    {
        AnouncePlayer.SetActive(true);
        AnounceSmash.SetActive(true);
        //AnouncePlayer
        AnouncePlayer.GetComponent<TweenPosition>().PlayForward();
        AnounceSmash.GetComponent<TweenPosition>().PlayForward();
    }

    private void PowerBarMinus()
    {
        timerPower -= Time.deltaTime;
        //PowerBar.value = timerPower;
    }
}