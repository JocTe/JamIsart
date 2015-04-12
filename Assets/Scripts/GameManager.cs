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

    public float TimerPhaseMovement = 7.0f;
    private float timerMovePhase = 0.0f;
    private float timerPower;
    public int InputToSmash = 15;
    private int inputSmash = 0;

    private void Start()
    {
        timerMovePhase = TimerPhaseMovement;
        timerPower = TimerPhaseMovement;
    }

    private void OnEnable()
    {
        isInputPhase = true;
    }

    private void GetRandomPlayer()
    {
     
    }

    private void Update()
    {
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

    private void PowerBarMinus()
    {
        timerPower -= Time.deltaTime;
        //PowerBar.value = timerPower;
    }
}