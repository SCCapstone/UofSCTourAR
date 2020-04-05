using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryReset : MonoBehaviour
{
    public void resetHistory()
    {
        for (int i = HistoryList.listHistory.Count - 1; i >=0; i--)
        {
            HistoryList.listHistory.RemoveAt(i);
        }
    }
}
