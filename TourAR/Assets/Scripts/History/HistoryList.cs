using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryList : MonoBehaviour
{
    public static List<string> listHistory = new List<string>();
    public int stopsCount = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        stopsCount = listHistory.Count;
        score.text = "Total stops visited:\n" + stopsCount;
    }

    public List<string> GetHistory() {
        return listHistory;
    }

    public static void addToTourHistory(string bID)
    {
        Debug.Log("\n\n\n\n ****************** \n\n\n\n ADD TO TOUR HISTORY CALLED \n\n\n\n ****************** \n\n\n\n");
        var mTH = new manageTourHistory();
        mTH.addStopToHistory(bID);
        Debug.Log("\n\n\n\n ****************** \n\n\n\n ADDED TO MANAGE TOUR HISTORY. NOW UPDATING LIST HISTORY IN HISTORY LIST. \n\n\n\n ****************** \n\n\n\n");
        listHistory = manageTourHistory.getTourHistoryAsString();
    }
}