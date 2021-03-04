using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public GameObject checkbox;
    public float maxTime = 3;

    private float time = 0;

    private void Start()
    {
        TimeStatus(false);
    }

    private void Update()
    {
        slider.value = time / maxTime;

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

        if (time > maxTime)
        {
            TimeStatus(true);
            return;
        }

        TimeStatus(false);
    }

    private void TimeStatus(bool status)
    {
        checkbox.SetActive(status);
        buttonPressed = status;
    }
    public static bool buttonPressed = false;
}
