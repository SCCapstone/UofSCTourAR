using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MapRaycast : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] Text title;

    private List<TourStop> tourStops;
    public class TourStop
    {
        public string name;

        public string description;

        public string year;

        public string buildingID;

        public string location;

        public string closestPOI;

        public string[] photos;
    }

    void Start()
    { //initialize json
      string json = Resources.Load<TextAsset>("JSON/tourStops").text;
      tourStops = JsonConvert.DeserializeObject<List<TourStop>>(json);

    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("POI"))
                {
                    //set bID based on click
                    string bID = raycastHit.collider.GetComponent<cubePOI_ID>().buildingID;
                    Debug.Log("buildingID: " + bID);
                    loadTourStops.stopToLoad = bID;

                    //get title
                    string retVal = "";
                    for (int i = 0; i < tourStops.Count; i++)
                    {
                        if (tourStops[i].buildingID.Equals(bID))
                        {
                            retVal += tourStops[i].name;
                        }
                    }

                    title.text = "Would you like to visit the " + retVal + "?";

                    panel.SetActive(true);
                }
            }
        }
    }
}
