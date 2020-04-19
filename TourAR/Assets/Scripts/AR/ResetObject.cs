using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    private GameObject objectToChange = null;

    public void ResetRotation()
    {
        objectToChange = GameObject.Find("UofSC Cube");

        if (objectToChange != null)
        {
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing =
                new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            objectToChange
                .transform
                .SetPositionAndRotation(objectToChange.transform.position,
                Quaternion.LookRotation(cameraBearing));
        }
    }
}
