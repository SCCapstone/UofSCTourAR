using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageTourHistory : MonoBehaviour
{
    private List<tourStopVisited> tourHistory;
    private int tourHistoryCap = 10; //Setting as 10 by default
    public string filePath = Application.dataPath + "/tourHistory.json";

    /*
        Suggested Workflow:
          - Create an instance of manageTourHistory, which will load data from the JSON.
          - To add a stop:
            - call addStopToHistory() 
            - IMPORTANT: call saveTourHistory() otherwise this will not update the JSON file.
    */
    public manageTourHistory()
    {
        loadTourHistory();
    }

    public class tourStopVisited
    {
        public string stopID;

        public string completionDate;
    }

    public int getTourHistoryCap()
    {
        return tourHistoryCap;
    }

    public void setTourHistoryCap(int cap)
    {
        if (cap > 0)
        {
            tourHistoryCap = cap;
        }
    }

    private void loadTourHistory()
    {
        /*
            Application.dataPath is required because it is the only way to ensure that we are accessing our assets folder,
            on both desktop runs and mobile. 
        */

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
        if (tourHistory.Count >= tourHistoryCap)
        {
            // we need to remove the last element of the list before adding this one
            tourHistory.RemoveAt(tourHistoryCap - 1);
        }
        tourStopVisited newItem = new tourStopVisited();
        newItem.stopID = tourStopID;
        newItem.completionDate = date;
        tourHistory.Insert(0, newItem);
    }

    public void clearTourHistory()
    {
        tourHistory.RemoveRange(0, tourHistory.Count - 1);
    }

    public void saveTourHistory()
    {
        //THIS METHOD NEEDS TO BE CALLED TO UPDATE THE JSON FILE
        File.WriteAllText(filePath, JsonConvert.SerializeObject(tourHistory));
    }
}