using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public void Update()
    {
        if ((Equation.answerCorrect && Timer.buttonPressed)||(Timer.buttonPressed && NumberSequence.sequenceDone)
            ||(NumberSequence.sequenceDone))
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }
    }
}
