using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{

    // Assign in the inspector
     public GameObject objectToRotate;
     public Slider slider;

     [SerializeField] ARPlacementIndicator status;
     private bool objHasSpawned=false;
     private bool counter=false;

     // Update is called once per frame
     void Update()
     {
       objHasSpawned = status.getStatus();


       if (objHasSpawned && counter==false) {
         objectToRotate = GameObject.Find("UofSC Cube");
         counter=true;
       }
     }

     // Preserve the original and current orientation
     private float previousValue;

     void Awake ()
     {
         // Assign a callback for when this slider changes
         this.slider.onValueChanged.AddListener(this.OnSliderChanged);

         // And current value
         this.previousValue = this.slider.value;
     }

     void OnSliderChanged (float value)
     {
       if (objHasSpawned) {
         slider.value = objectToRotate.transform.eulerAngles.y;

         Vector3 current = objectToRotate.transform.eulerAngles;
         objectToRotate.transform.rotation = Quaternion.Euler(current.x, slider.value, current.z);


         /*
         // How much we've changed
         float delta = value - this.previousValue;
         this.objectToRotate.transform.Rotate (Vector3.right * delta * 360);

         // Set our previous value for the next change
         this.previousValue = value;
         */
        }
      }

}
