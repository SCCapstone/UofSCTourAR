using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadDataToAR : MonoBehaviour
{
    public Text data;
    loadTourStops tourStops;
    // Start is called before the first frame update
    void Start()
    {
      loadText();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void loadText() {
      Debug.Log("loadText");
      data.text = tourStops.getMetadataForTourStop("n/a");
    }

}
