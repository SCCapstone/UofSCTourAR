using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAR : MonoBehaviour
{
    [SerializeField] GameObject placementIndicator;
   

    public void Reset() {
        GameObject uofscCube = GameObject.Find("UofSC Cube");
        Destroy(uofscCube);

        placementIndicator.SetActive(true);
    }
}
