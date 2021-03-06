﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryList : MonoBehaviour
{
    public static List<string> listHistory = new List<string>();

    public static int stopsCount = 0;

    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        stopsCount = listHistory.Count;
        score.text = "Total stops visited:\n" + stopsCount;
    }

    public List<string> GetHistory()
    {
        return listHistory;
    }

    public static void addToTourHistory(string bID)
    {
        var mTH = new manageTourHistory();
        mTH.addStopToHistory (bID);
        listHistory = manageTourHistory.getTourHistoryAsString();
    }
}
