using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public static List<GameObject> buttons;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        buttons = new List<GameObject>();
        HistoryList.listHistory = manageTourHistory.getTourHistoryAsString();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        List<loadTourStops.TourStop> tourStops = loadTourStops.tourStops;

        foreach (string name in HistoryList.listHistory)
        {
            string bID="";
            //find buildingID
            for (int i=0; i<tourStops.Count; i++) {
                if (tourStops[i].name.Equals(name)) {
                    bID = tourStops[i].buildingID;
                }
            }

            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<HistoryListButton>().setInfo(name, bID);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public static void Reset()
    {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("HButton"))
        {
            Destroy (gameObj);
        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log (myTextString);
    }
}
