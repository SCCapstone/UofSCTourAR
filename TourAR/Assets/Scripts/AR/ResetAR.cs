using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAR : MonoBehaviour
{
    [SerializeField] GameObject placementIndicator;
   

    public void Reset() {

        GameObject[] objectsToDelete;

        objectsToDelete = GameObject.FindGameObjectsWithTag("ARObject");

        foreach (GameObject obj in objectsToDelete) {
            Debug.Log("Destroyed: " + obj.name);
            Destroy(obj);
        }

        objectsToDelete = GameObject.FindGameObjectsWithTag("ARObject");

        Debug.Log("Objects were destroyed");
        foreach(GameObject obj in objectsToDelete) {
            Debug.Log(obj.name);
        }

        placementIndicator.SetActive(true);
    }
}
