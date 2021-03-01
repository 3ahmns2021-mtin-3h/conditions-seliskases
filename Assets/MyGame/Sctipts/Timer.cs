using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;

    private void Update()
    {
        if (buttonPressed)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            time = 0;
        }

        if (time > 3)
        {
            TimeStatus(true);
            return;
        }

        TimeStatus(false);
    }

    #region TimeSingleton
    private void TimeStatus(bool status)
    {
        buttonPressed = status;
    }
    public static bool buttonPressed;
    #endregion
}
