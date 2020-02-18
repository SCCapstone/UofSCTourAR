using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{

    private GameObject objectToDelete;

    [SerializeField] GameObject plcIndObject;
    ARPlacementIndicator plcInd;

    // Start is called before the first frame update
    void Start()
    {
      plcIndObject.GetComponent<ARPlacementIndicator>();
    }

    public void Delete() {
      objectToDelete.Destroy();
      plcInd.objectPlaced = false;
      plcIndObject.SetActive(true);
    }
}
