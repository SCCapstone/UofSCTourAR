using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageTourHistory : MonoBehaviour
{
    private static List<tourStopVisited> tourHistory;
    private int tourHistoryCap = 10; //Setting as 10 by default

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
        string json = Resources.Load<TextAsset>("JSON/tourHistory").text;
        tourHistory = JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
    }

    public List<tourStopVisited> getTourHistory()
    {
        return tourHistory;
    }

    public void addStopToHistory(string tourStopID)
    {
        if (tourHistory.Count >= tourHistoryCap)
        {
            // we need to remove the last element of the list before adding this one
            tourHistory.RemoveAt(tourHistoryCap - 1);
        }
        tourStopVisited newItem = new tourStopVisited();
        newItem.stopID = tourStopID;
        tourHistory.Insert(0, newItem);
        saveTourHistory();
    }

    public void clearTourHistory()
    {
        tourHistory.RemoveRange(0, tourHistory.Count);
    }

    public void saveTourHistory()
    {
        File.WriteAllText("Assets/Resources/JSON/tourHistory.json", JsonConvert.SerializeObject(tourHistory));
    }
}