﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageTourHistory : MonoBehaviour
{
    private List<tourStopVisited> tourHistory;

    // Start is called before the first frame update
    void Start()
    {
        loadTourHistory();
    }

    public class tourStopVisited
    {
        public string name;
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

    public void addStopToHistory(string stopName, string completionDate)
    {
        //TODO add functionality
    }
}