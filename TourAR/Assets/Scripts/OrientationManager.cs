using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationManager : MonoBehaviour
{

    [SerializeField] public bool portraitOnly = true;
    // Start is called before the first frame update
    void Start()
    {
      checkOrientation();
    }

    // Update is called once per frame
    void Update()
    {
      //add button to player settings
      //checkOrientation();
    }

    private void checkOrientation() {

      if (portraitOnly){
        Screen.autorotateToPortrait = true;
      } else {
        Screen.autorotateToPortrait = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
      }
    }
}
