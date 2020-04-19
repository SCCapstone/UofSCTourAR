using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryReset : MonoBehaviour
{
    public void resetHistory()
    {
        var mTH = new manageTourHistory();
        mTH.clearTourHistory();
        if (HistoryListControl.buttons.Count > 0)
        {
            foreach (GameObject button in HistoryListControl.buttons)
            {
                Destroy(button.gameObject);
            }
            HistoryListControl.buttons.Clear();
        }
        HistoryListControl.Reset(); //Deletes the button gameobjects
    }
}
