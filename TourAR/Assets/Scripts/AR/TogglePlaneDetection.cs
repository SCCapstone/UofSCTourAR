using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TogglePlaneDetection : MonoBehaviour
{

    [SerializeField] public GameObject arSessionOrigin;
    private ARPlaneManager plane;
    [SerializeField] Text buttonText;


    // Start is called before the first frame update
    void Start()
    {
      plane = arSessionOrigin.GetComponent<ARPlaneManager>();
    }

    public void TogglePD() {
      plane.enabled = !plane.enabled;
      buttonText.text = (plane.enabled) ? "Plane Detection: On" : "Plane Detection: Off";

    }
}
