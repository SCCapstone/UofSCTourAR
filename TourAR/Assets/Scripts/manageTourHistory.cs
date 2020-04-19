using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageTourHistory : MonoBehaviour
{
    private static List<tourStopVisited> tourHistory;
    private static int tourHistoryCap = 10; //Setting as 10 by default

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

    public static List<string> getTourHistoryAsString()
    {
        List<string> histStrList = new List<string>();
        for (int i = 0; i < tourHistory.Count; i++)
        {
            histStrList.Add(tourHistory[i].stopID);
        }
        return histStrList;
    }

    public static void loadTourHistory()
    {
        if (File.Exists(Application.persistentDataPath + "/tourHistory.json"))
        {
            string filePath = Application.persistentDataPath + "/tourHistory.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                tourHistory = JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
            }
        }
        else {
            string json = Resources.Load<TextAsset>("JSON/tourHistory").text;
            tourHistory = JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
        }
    }

    public List<tourStopVisited> getTourHistory()
    {
        return tourHistory;
    }

    public void addStopToHistory(string tourStopID)
    {
        if (tourHistory.Count >= tourHistoryCap)
        {
            tourHistory.RemoveAt(tourHistoryCap - 1); // we need to remove the last element of the list before adding this one
        }
        tourStopVisited newItem = new tourStopVisited();
        newItem.stopID = tourStopID;
        tourHistory.Insert(0, newItem);
        saveTourHistory();
        Debug.Log("STOP ADDED TO TOUR HISTORY");
    }

    public void clearTourHistory()
    {
        tourHistory.RemoveRange(0, tourHistory.Count);
    }

    private static void saveTourHistory()
    {
        Debug.Log("SAVING TOUR HISTORY NOW");
        string filePath = Application.persistentDataPath + "/tourHistory.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(tourHistory));
    }
}