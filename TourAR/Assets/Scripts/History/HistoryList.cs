using System.Collections;
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
        score = GetComponent<Text> ();
        listHistory.Add("Hello1");
        listHistory.Add("Hello2");
        listHistory.Add("Hello3");
        Debug.Log("Hello");
        Debug.Log(listHistory[1]);
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
}