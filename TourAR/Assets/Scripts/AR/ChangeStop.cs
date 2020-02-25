using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStop : MonoBehaviour
{
    Dropdown myDropdown;

    public static bool hasChanged=false;

    public void OnDropDownChanged(Dropdown dropDown)
    {
      string stopName="";

      switch (dropDown.value) {
        case 1:
          stopName="Rutledge";
          break;
        case 2:
          stopName="Horseshoe";
          break;
        case 3:
          stopName="McKissick";
          break;
      }

      loadTourStops.stopToLoad = stopName;
      hasChanged = true;
    }


    public void OnARSelect(string stopName) {
      loadTourStops.stopToLoad = stopName;
      hasChanged = true;
      Debug.Log("ChangeStop: "+ loadTourStops.stopToLoad);
    }
}
