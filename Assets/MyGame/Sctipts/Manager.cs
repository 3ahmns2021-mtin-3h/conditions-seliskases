using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Image statusImage;

    public Color trueColor;
    public Color falseColor;

    public bool answerCorrectDebug;
    public bool buttonPressedDebug;
    public bool sequenceDoneDebug;
    public bool movedStatusDebug;

    public void Update()
    {
        answerCorrectDebug = Equation.answerCorrect;
        buttonPressedDebug = Timer.buttonPressed;
        sequenceDoneDebug = NumberSequence.sequenceDone;
        movedStatusDebug = DragObject.movedStatus;

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

    public void Restart()
    {
        //Equation.answerCorrect = false;
        //Timer.buttonPressed = false;
        //NumberSequence.sequenceDone = false;
        //DragObject.movedStatus = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
