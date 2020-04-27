using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchButtonControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public static List<GameObject> buttons;

    private List<loadTourStops.TourStop> tourStops;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        tourStops = loadTourStops.tourStops;

        /*
        foreach (loadTourStops.TourStop ts in tourStops) {
            Debug.Log(ts.name);
        }*/

        buttons = new List<GameObject>();
        //HistoryList.listHistory = manageTourHistory.getTourHistoryAsString();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button);
            }
            buttons.Clear();
        }

        //sort local list
        bubbleSort();

        for (int i = 0; i < tourStops.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<SearchButton>().setInfo(tourStops[i].name, tourStops[i].buildingID);
            //button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.transform.SetParent(buttonTemplate.transform.parent);
        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log (myTextString);
    }

    void bubbleSort() 
    { 
        int len = tourStops.Count;
        loadTourStops.TourStop temp;

        for (int j = 0; j < len - 1; j++) 
        { 
            for (int i = j + 1; i < len; i++)  
            { 
                if (tourStops[j].name.CompareTo(tourStops[i].name) > 0) 
                { 
                    temp = tourStops[j]; 
                    tourStops[j] = tourStops[i]; 
                    tourStops[i] = temp; 
                } 
            } 
        } 
        //tourStops.RemoveRange(0, len);
    } 
}
