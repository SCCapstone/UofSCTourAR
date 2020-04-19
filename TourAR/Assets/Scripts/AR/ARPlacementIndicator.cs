using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;

    [SerializeField]
    GameObject indicator;

    [SerializeField]
    GameObject objectToPlace;

    [SerializeField]
    GameObject transparentBox;

    public bool objectPlaced = false;

    private Pose placementPose;

    private bool placementPoseIsValid = false;

    public GameObject

            movePhone,
            doubleTapPhone; //animated icons in UI

    //[SerializeField] Text ObjectLocText;
    void Start()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();

        //indicator = transform.GetChild(0).gameObject;
        //hide the placement indicator visual if not already hidden
        indicator.SetActive(false);
    }

    void Update()
    {
        if (!objectPlaced)
        {
            //only raycasts before object has been placed
            // shoot a raycast from the center of the screen
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            rayManager
                .Raycast(new Vector2(Screen.width / 2, Screen.height / 2),
                hits,
                TrackableType.Planes);

            // if we hit an AR plane surface, update the position and rotation
            placementPoseIsValid = hits.Count > 0;
            if (placementPoseIsValid)
            {
                //update placement pose
                placementPose = hits[0].pose;

                var cameraForward = Camera.current.transform.forward;
                var cameraBearing =
                    new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
                placementPose.rotation = Quaternion.LookRotation(cameraBearing);

                indicator.transform.position = placementPose.position; // only change position
                transparentBox
                    .transform
                    .SetPositionAndRotation(placementPose.position,
                    placementPose.rotation);

                //transparentBox.transform.position = placementPose.position; //keeps box in the same position
                //indicator.transform.position = hits[0].pose.position;
                //transparentBox.transform.position = hits[0].pose.position; //keeps box in the same position
                //indicator.transform.rotation += hits[0].pose.rotation;
                //Debug.Log(indicator.transform.position +" , "+indicator.transform.rotation);
                // enable the indicator if it's disabled
                if (!indicator.activeInHierarchy)
                {
                    indicator.SetActive(true);
                    transparentBox.SetActive(true);
                    movePhone.SetActive(false);
                    doubleTapPhone.SetActive(true);
                }

                DoubleTap();
            }
        }
    }

    private void PlaceObject()
    {
        doubleTapPhone.SetActive(false);
        Instantiate(objectToPlace,
        placementPose.position,
        placementPose.rotation);

        //Debug.Log("****Instantiate Object: ");
        //ObjectLocText.text = "Position: "+ indicator.transform.position;
        //objectPlaced = true;
        //if(indicator.activeInHierarchy) { //turn off placement indicator parent
        gameObject.SetActive(false);
        //Debug.Log("gameObject is off");

        //}
    }

    private void DoubleTap()
    {
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

    public bool getStatus()
    {
        return objectPlaced;
    }
}
