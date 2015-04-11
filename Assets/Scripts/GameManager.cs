using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement PlayerScript;

    private bool isMovePhase = false;
    private bool isInputPhase = false;

    public float TimerPhaseMovement = 7.0f;
    private float timerMovePhase = 0.0f;
    public int InputToSmash = 15;
    private int inputSmash = 0;

    private void Start()
    {
        timerMovePhase = TimerPhaseMovement;
    }

    private void OnEnable()
    {
        isInputPhase = true;
    }

    private void Update()
    {
        if (isInputPhase == true)
        {
            InputPhase();
            Debug.Log("Input " + inputSmash);
        }
        else if (isMovePhase == true)
        {
            MovePhase();
        }
    }

    private void InputPhase()
    {
        PlayerScript.enabled = false;
        if (Input.GetButtonDown("ButtonA"))
        {
            inputSmash++;
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
        Debug.Log("Move PHASE");
        PlayerScript.enabled = true;
        timerMovePhase += Time.deltaTime;
        if (timerMovePhase >= TimerPhaseMovement)
        {
            isMovePhase = false;
            isInputPhase = true;
            inputSmash = 0;
        }
    }
}