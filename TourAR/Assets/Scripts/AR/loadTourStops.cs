using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class loadTourStops : MonoBehaviour
{
    public static List<TourStop> tourStops;

    public Text stopTitle;

    public Text data;

    public static string stopToLoad = "yes";

    public static List<string> imageNames = new List<string>(); //public static List<string> imageNames = new List<string>();

    [SerializeField] bool notAR = false;

    void Start()
    {
        loadTheTourStops();

        if (!notAR) {
            sendToAR();
        }
        
        /*
        Debug.Log("loadourstops: " + imageNames);
        int counter = 0;
        foreach (var name in imageNames)
        {
            Debug.Log("loadourstops: " + counter + " " + name);
            counter++;
        }
        */
    }

    public class TourStop
    {
        public string name;

        public string description;

        public string year;

        public string buildingID;

        public string location;

        public string closestPOI;

        public string[] photos;
    }

    private void sendToAR()
    {
        stopTitle.text = this.getTitleForTourStop(stopToLoad);
        data.text = this.getMetadataForTourStop(stopToLoad);
        setPhotosForTourStop (stopToLoad);
    }

    public void sendToPopUp()
    {
        stopTitle.text = this.getTitleForTourStop(stopToLoad);
        data.text = this.getMetadataForTourStop(stopToLoad);
    }

    private void loadTheTourStops()
    {
        string json = Resources.Load<TextAsset>("JSON/tourStops").text;

        //Debug.Log("JSON DATA:  "+ json);
        tourStops = JsonConvert.DeserializeObject<List<TourStop>>(json);
        //Debug.Log("finished convert");
    }

    public void prepForUse()
    {
        loadTheTourStops();
    }

    public List<TourStop> getTourStops()
    {
        return tourStops;
    }

    public string getTitleForTourStop(string bID)
    {
        //title
        string retVal = "";
        for (int i = 0; i < tourStops.Count; i++)
        {
            if (tourStops[i].buildingID.Equals(bID))
            {
                Debug.Log("buildingID: " + bID);
                retVal += tourStops[i].name;
            }
        }
        if (retVal == "")
        {
            retVal = "n/a no match found for this building ID";
        }
        return retVal;
    }

    public string getMetadataForTourStop(string bID)
    {
        // constructed:
        // Location:
        // description:
        string retVal = "";
        for (int i = 0; i < tourStops.Count; i++)
        {
            if (tourStops[i].buildingID.Equals(bID))
            {
                retVal += "<b>Constructed:</b> " + tourStops[i].year;
                retVal += "\n\n<b>Location:</b> " + tourStops[i].location;
                retVal += "\n\n<b>Description:</b> " + tourStops[i].description;
            }
        }
        return retVal;
    }

    public void setPhotosForTourStop(string bID)
    {
        clearImageNames();
        for (int i = 0; i < tourStops.Count; i++)
        {
            if (tourStops[i].buildingID.Equals(bID))
            {
                for (int j = 0; j < tourStops[i].photos.Length; j++)
                {
                    imageNames.Add(tourStops[i].photos[j]);
                }
            }
        }
    }

    public static string[] getAllDataForTourStop(string bID)
    {
        string[] retVal = new string[2];
        for (int i = 0; i < tourStops.Count; i++)
        {
            if (tourStops[i].buildingID.Equals(bID))
            {
                retVal[0] = tourStops[i].name;
                retVal[1] = tourStops[i].description;
                retVal[3] = tourStops[i].year;
                retVal[4] = tourStops[i].buildingID;
                retVal[5] = tourStops[i].location;
                retVal[6] = tourStops[i].closestPOI;
            }
        }
        return retVal;
    }

    public string getStopDescription(string stopName)
    {
        for (int i = 0; i < tourStops.Count; i++)
        {
            if (tourStops[i].name.Equals(stopName))
            {
                return tourStops[i].description;
            }
        }
        return "n/a couldn't find a match";
    }

    public void clearImageNames()
    {
        for (int i = imageNames.Count - 1; i >= 0; i--)
        {
            imageNames.RemoveAt (i);
        }
    }
}
