using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class loadTourStops : MonoBehaviour
{
    private List<TourStop> tourStops;

    public loadTourStops()
    {
        loadTheTourStops();
    }

    public class TourStop
    {
        public string name;

        public string description;

        public string pictureName;
        
        public string year;

        public string buildingID;

        public string location;

        public string closestPOI;
    }

    private void loadTheTourStops()
    {
        /*
            Application.dataPath is required because it is the only way to ensure that we are accessing our assets folder,
            on both desktop runs and mobile. 
        */
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
