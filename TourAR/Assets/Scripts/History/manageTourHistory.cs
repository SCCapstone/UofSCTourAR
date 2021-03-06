﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

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
        loadTourHistory();
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
                tourHistory =
                    JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
            }
        }
        else
        {
            string json = Resources.Load<TextAsset>("JSON/tourHistory").text;
            tourHistory =
                JsonConvert.DeserializeObject<List<tourStopVisited>>(json);
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

        // Try to convert Building ID to stop name
        var manageTS = new loadTourStops();
        manageTS.prepForUse();
        string title = manageTS.getTitleForTourStop(tourStopID); // stop name
        tourStopVisited newItem = new tourStopVisited();
        if (
            title == "n/a no match found for this building ID" // If we did not find a name for the ID. Realistically this should only happen with our fake tour stops for testing.
        )
        {
            newItem.stopID = tourStopID;
        }
        else
        {
            newItem.stopID = title;
        }
        tourHistory.Insert(0, newItem);
        saveTourHistory();
    }

    public void clearTourHistory()
    {
        tourHistory.RemoveRange(0, tourHistory.Count);
        saveTourHistory();
    }

    private static void saveTourHistory()
    {
        string filePath = Application.persistentDataPath + "/tourHistory.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(tourHistory));
    }
}
