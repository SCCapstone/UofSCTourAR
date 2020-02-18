using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ARPlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject indicator;
    [SerializeField] GameObject objectToPlace;
    public bool objectPlaced = false;

    [SerializeField] Text ObjectLocText;

    void Start ()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        indicator = transform.GetChild(0).gameObject;

        //hide the placement indicator visual if not already hidden
        indicator.SetActive(false);
    }
    void Update ()
    {
      if (!objectPlaced) { //only raycasts before object has been placed
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit an AR plane surface, update the position and rotation
        if(hits.Count > 0)
        {
            indicator.transform.position = hits[0].pose.position;
            //indicator.transform.rotation += hits[0].pose.rotation;
            //Debug.Log(indicator.transform.position +" , "+indicator.transform.rotation);


            // enable the indicator if it's disabled
            if(!indicator.activeInHierarchy)
                indicator.SetActive(true);

            DoubleTap();

            /*
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        		{
        			PlaceObject();
        		}
            */

        }
      }

    }

    private void PlaceObject()
  	{

  		Instantiate(objectToPlace, indicator.transform.position, indicator.transform.rotation);
      //Debug.Log("****Instantiate Object: ");
      //ObjectLocText.text = "Position: "+ indicator.transform.position;
      //objectPlaced = true;

      //TODO: Rotate Object
      //objectToPlace.transform.rotation.y = Camera.main.transform.rotation.y;
      //Quaternion.Euler(indicator.transform.rotation.x, Camera.main.transform.rotation.y, indicator.transform.rotation.z)

      //if(indicator.activeInHierarchy) { //turn off placement indicator parent
      gameObject.SetActive(false);
      //Debug.Log("gameObject is off");

      //}
  	}

    private void DoubleTap() {

      for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    Debug.Log("Double Tap");
                    PlaceObject();
                }
            }
        }
    }

    public bool getStatus() {
      return objectPlaced;
    }

}
