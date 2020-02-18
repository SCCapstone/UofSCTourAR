using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadDataToAR : MonoBehaviour
{
    public Text data;
    public string text;
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
      data.text = tourStops.name;
    }

}
