using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberSequence : MonoBehaviour
{
    public KeyCode[] keyCodes;

    public TextMeshProUGUI numberField;
    public GameObject checkbox;

    private int num = 0;
    private Coroutine currentCoroutine = null;

    private void Start()
    {
        SequenceStatus(false);
        currentCoroutine = StartCoroutine(KeyListener(keyCodes[num]));
    }

    private void Update()
    {
        if (!sequenceDone)
        {
            numberField.text = (num + 1).ToString();
        }
    }

    private IEnumerator KeyListener(KeyCode keyCode)
    {
        while (true)
        {
            if (Equation.inputFieldSelected)
            {
                yield return null;
            }

            //If the numbers aren't pressed in the correct order -> restart
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (i != num)
                {
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        num = 0;
                        yield return null;

                        NextCoroutine();
                    }
                }
            }

            if (Input.GetKeyDown(keyCode))
            {
                num++;
                if (num >= keyCodes.Length)
                {
                    SequenceStatus(true);
                    StopAllCoroutines();
                    break;
                }

                yield return null;
                NextCoroutine();
            }

            yield return null;
        }
    }

    private void NextCoroutine()
    {
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(KeyListener(keyCodes[num]));
    }

    private void SequenceStatus(bool status)
    {
        checkbox.SetActive(status);
        sequenceDone = status;
    }
    public static bool sequenceDone = false;
}
