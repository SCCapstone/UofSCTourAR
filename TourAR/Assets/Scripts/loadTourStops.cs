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

    public string getMetadataForTourStop(string bID) {
        //constructed:
        // Location:
        // description:
        string retVal = "";
        for(int i = 0; i < tourStops.Count; i++)
        {
            if(tourStops[i].buildingID.Equals(bID))
            {
                retVal += "<b>Contstructed: </b>" + tourStops[i].year;
                retVal += "<br>Location: " + tourStops[i].location;
                retVal += "\nDescription: " + tourStops[i].description;
            }
        }
        return retVal;
    }

    public string[] getAllDataForTourStop(string bID) {
        string[] retVal = new string[2];
        for(int i = 0; i < tourStops.Count; i++) 
        {
            if(tourStops[i].buildingID.Equals(bID)) 
            {
                retVal[0] = tourStops[i].name;
                retVal[1] = tourStops[i].description;
                retVal[2] = tourStops[i].pictureName;
                retVal[3] = tourStops[i].year;
                retVal[4] = tourStops[i].buildingID;
                retVal[5] = tourStops[i].location;
                retVal[6] = tourStops[i].closestPOI;
            }
        }
        return retVal;
    }
}
