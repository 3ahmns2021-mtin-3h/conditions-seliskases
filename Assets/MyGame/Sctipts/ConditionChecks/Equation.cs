using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Equation : MonoBehaviour
{
    public TextMeshProUGUI equationText;
    public TMP_InputField answerField;
    public GameObject checkbox;
    public double tolerance;
    public bool debugAnswers;
    public static bool inputFieldSelected;

    private double correctAnswer;

    public void Start()
    {
        CreateEquation();
        AnswerStatus(false);
    }

    public void CreateEquation()
    {
        int id = Random.Range(1, 3);
        switch (id)
        {
            case 1:
                equationText.text = PatternOne();
                break;
            case 2:
                equationText.text = PatternTwo();
                break;
        }

        if (debugAnswers)
        {
            Debug.Log(correctAnswer);
        }
    }

    public void OnInputChanged()
    {
        double inputValue;
        if (double.TryParse(answerField.text, out inputValue))
        {
            double n = inputValue - correctAnswer;
            if(n < 0)
            {
                n = n * (-1);
            }

            if (n < tolerance)
            {
                AnswerStatus(true);
                return;
            }
        }

        AnswerStatus(false);
    }    

    public string PatternOne()
    {
        float[] values = new float[3];
        for(int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(2, 250);
        }   

        correctAnswer = (values[2] - values[1]) / values[0];
        return values[0] + " * x + " + values[1] + " = " + values[2];

        //Equation: a * x + b = c
        //Solution: x = (c - b) / a
    }

    public string PatternTwo()
    {
        float[] values = new float[3];
        for(int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(2, 20);
        }

        correctAnswer = values[0] * values[1] * values[2];
        return "x / " + values[0] + " = " + values[1] + " * " + values[2];

        //Equation: x / a = b * c
        //Solution: x = a * b * c
    }

    public void OnSelectInputField()
    {
        inputFieldSelected = true;
    }

    public void OnDeselectInputField()
    {
        inputFieldSelected = false;
    }

    private void AnswerStatus(bool status)
    {
        checkbox.SetActive(status);
        answerCorrect = status;
    }
    public static bool answerCorrect = false;
}
