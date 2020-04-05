﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class loadTourStops : MonoBehaviour
{
    public static List<TourStop> tourStops;
    public Text stopTitle;
    public Text data;
    public static string stopToLoad = "Horseshoe";

    public static List<string> imageNames = new List<string>();    //public static List<string> imageNames = new List<string>();

    //ChangeStop change;
    //public Dropdown selection; Dropdown did not work as intended
    //private int prevDropVal=-1;

    void Start()
    {
        loadTheTourStops();
        sendToAR();

        Debug.Log("loadourstops: " + imageNames);
        int counter = 0;
        foreach (var name in imageNames)
        {
            Debug.Log("loadourstops: " + counter + " " + name);
            counter++;
        }
    }

    void Update()
    {
        //if (prevDropVal != selection.value)
        //sendToAR();
        if (ChangeStop.hasChanged)
        {
            sendToAR();
            ChangeStop.hasChanged = false;
        }

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
        Debug.Log("sendToAR: " + stopToLoad);
        //Debug.Log(selection.options[selection.value].text);
        //Debug.Log(selection.captionText.text);
        stopTitle.text = this.getTitleForTourStop(stopToLoad);
        data.text = this.getMetadataForTourStop(stopToLoad);
        setPhotosForTourStop(stopToLoad);
    }

    public void sendToSearch(string currentStop)
    {
        Debug.Log("sendToSearch: " + stopToLoad);
        data.text = this.getMetadataForTourStop(currentStop);

        /**
        for (int i = 0; i < loadTourStops.tourStops.Count; i++)
        {
            string currStop = loadTourStops.tourStops[i].buildingID;

            // do something like get description. You can get any attributes or do anything here.
            Debug.Log(loadTourStops.tourStops[i].name);
            data.text = getMetadataForTourStop(currStop);
        }
        **/
    }

    private void loadTheTourStops()
    {
        string json = Resources.Load<TextAsset>("JSON/tourStops").text;
        //Debug.Log("JSON DATA:  "+ json);
        tourStops = JsonConvert.DeserializeObject<List<TourStop>>(json);
        //Debug.Log("finished convert");
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
                retVal += "\n<b>Location:</b> " + tourStops[i].location;
                retVal += "\n<b>Description:</b> " + tourStops[i].description;
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

    public string[] getAllDataForTourStop(string bID)
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
    
    public void clearImageNames() {
        for (int i = imageNames.Count - 1; i >=0; i--)
        {
            imageNames.RemoveAt(i);
        }
    }
}