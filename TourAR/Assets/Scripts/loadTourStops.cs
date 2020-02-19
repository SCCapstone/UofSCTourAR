using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class loadTourStops : MonoBehaviour
{
    private List<TourStop> tourStops;
    public Text stopTitle;
    public Text data;
    public string stopToLoad = "Rutledge";
    //public Dropdown selection; Dropdown did not work as intended
    //private int prevDropVal=-1;

    void Start() {

      loadTheTourStops();
      sendToAR();
    }

    void Update() {
      //if (prevDropVal != selection.value)
        //sendToAR();
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

    private void sendToAR() {
      Debug.Log("sendToAR");
      //Debug.Log(selection.options[selection.value].text);
      //Debug.Log(selection.captionText.text);
      stopTitle.text = this.getTitleForTourStop(stopToLoad);
      data.text = this.getMetadataForTourStop(stopToLoad);
    }


    private void loadTheTourStops()
    {
        string json = Resources.Load<TextAsset>("JSON/tourStops").text;
        //Debug.Log("JSON DATA:  "+ json);
        tourStops = JsonConvert.DeserializeObject<List<TourStop>>(json);

    }

    public List<TourStop> getTourStops()
    {
        return tourStops;
    }

    public string getTitleForTourStop(string bID) {
        //title
        string retVal = "";
        for(int i = 0; i < tourStops.Count; i++)
        {
            if(tourStops[i].buildingID.Equals(bID))
            {
                Debug.Log("buildingID: "+bID);
                retVal += tourStops[i].name;
            }
        }
        return retVal;
    }

    public string getMetadataForTourStop(string bID) {
        // constructed:
        // Location:
        // description:
        string retVal = "";
        for(int i = 0; i < tourStops.Count; i++)
        {
            if(tourStops[i].buildingID.Equals(bID))
            {
                retVal += "<b>Constructed:</b> " + tourStops[i].year;
                retVal += "\n<b>Location:</b> " + tourStops[i].location;
                retVal += "\n<b>Description:</b> " + tourStops[i].description;
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
