using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class loadTourStops : MonoBehaviour
{
    private List<TourStop> tourStops;

    // Start is called before the first frame update
    void Start()
    {
        loadTheTourStops();
    }

    public class TourStop
    {
        public string name;
        public bool isVisited;
        public string description;
    }

    private void loadTheTourStops()
    {
        string filePath = Application.dataPath + "/tourStops.json";
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            tourStops = JsonConvert.DeserializeObject<List<TourStop>>(json);
        }
    }

    public List<TourStop> getTourStops()
    {
        return tourStops;
    }

}
