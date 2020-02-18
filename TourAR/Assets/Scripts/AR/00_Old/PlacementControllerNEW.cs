using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARRaycastManager))]

public class PlacementControllerNEW : MonoBehaviour
{

    [SerializeField] private GameObject placedPrefab;

    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.touchCount > 0)
        {
          Touch touch = Input.GetTouch(0);

          if (touch.phase == TouchPhase.Began)
          {
            touchPosition = touch.position;

            if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;
                Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }

          }

        }
    }

}
