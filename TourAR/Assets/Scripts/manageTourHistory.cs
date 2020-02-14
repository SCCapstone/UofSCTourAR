using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageTourHistory : MonoBehaviour
{
    private List<tourStopVisited> tourHistory;

    public manageTourHistory() {
        loadTourHistory();
    }

    public class tourStopVisited
    {
        public string stopID;

        public string completionDate;
    }

    private void loadTourHistory()
    {
        /*
            Application.dataPath is required because it is the only way to ensure that we are accessing our assets folder,
            on both desktop runs and mobile. 
        */
        string filePath = Application.dataPath + "/tourHistory.json";

        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            tourHistory = JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
        }

    }

    public List<tourStopVisited> getTourHistory()
    {
        return tourHistory;
    }

    public void addStopToHistory(string tourStopID, string date)
    {
        if(tourHistory.Count < 10) {
            // If we don't have to worry about there being too many we can just add.
            tourStopVisited newItem = new tourStopVisited();
            newItem.stopID = tourStopID;
            newItem.completionDate = date;
            tourHistory.Insert(0, newItem);
        }
    }
}
