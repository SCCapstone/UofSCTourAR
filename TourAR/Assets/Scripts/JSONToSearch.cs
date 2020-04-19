using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JSONToSearch : MonoBehaviour
{
    [SerializeField]
    private string path;

    private string jsonString;

    [SerializeField]
    private TextField popuptext;

    // Start is called before the first frame update
    void Start()
    {
        jsonString = File.ReadAllText(path);
        TourStop Horseshoe = JsonUtility.FromJson<TourStop>(jsonString);
    }

    public void ImportJSONData(TextField textObj, TourStop stop)
    {
        textObj.value = stop.description.ToString() + stop.year.ToString();
    }

    [Serializable]
    public class TourStop
    {
        public string description;

        public string year;
    }
}
