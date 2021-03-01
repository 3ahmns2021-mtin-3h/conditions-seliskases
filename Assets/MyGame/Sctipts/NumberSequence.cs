using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSequence : MonoBehaviour
{
    public KeyCode[] keyCodes;

    public int num = 0;

    private Coroutine currentCoroutine = null;

    private void Start()
    {
        currentCoroutine = StartCoroutine(KeyListener(keyCodes[num]));
    }

    private IEnumerator KeyListener(KeyCode keyCode)
    {
        while (true)
        {
            if (Input.GetKeyDown(keyCode))
            {
                num++;
                if (num >= keyCodes.Length)
                {
                    SequenceStatus(true);
                    break;
                }

                NextCoroutine();
            }

            for(int i = 0; i < num - 1; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    yield return 1;
                    num = 0;
                    NextCoroutine();
                }
            }

            yield return null;
        }
    }

    private void NextCoroutine()
    {
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(KeyListener(keyCodes[num]));
    }

    #region
    private void SequenceStatus(bool status)
    {
        sequenceDone = status;
    }
    public static bool sequenceDone;
    #endregion
}
