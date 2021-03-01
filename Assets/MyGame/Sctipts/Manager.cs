using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public Image statusImage;

    public Color trueColor;
    public Color falseColor;

    private void Start()
    {
        
    }

    public void Update()
    {
        if ((Equation.answerCorrect && Timer.buttonPressed)||(Timer.buttonPressed && NumberSequence.sequenceDone)
            ||(NumberSequence.sequenceDone && DragObject.movedStatus))
        {
            statusImage.color = trueColor;
        }
        else
        {
            statusImage.color = falseColor;
        }
    }
}
