using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalCameraPosition;

    private float shakeAmt = 0;

    public Camera mainCamera;
    private bool shake;
    private float timer = 0.0f;

    private void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            shakeAmt = Random.Range(0.1f, 3.0f);
            shake = true;
        }
        if (shake)
        {
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.13f);
        }
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            shake = false;
            timer = 0.0f;
        }
    }

    private void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    private void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }
}