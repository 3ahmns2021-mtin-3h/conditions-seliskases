using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject dragObject;
    public float distanceMargin;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = dragObject.transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(dragObject.transform.position, startPosition) > distanceMargin)
        {
            print("1");
            MovedStatus(true);
        }
    }

    #region
    private void MovedStatus(bool status)
    {
        movedStatus = status;
    }
    public static bool movedStatus;
    #endregion
}
