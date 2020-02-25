using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{

    public enum ButtonType {Next, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ButtonType button;


    void Start()
    {
      //loadTourStops.imageNames;
      //load list based on stop's images

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonTap() {
      switch(button) {
        case ButtonType.Next:
          next();
          break;
        case ButtonType.Back:
          back();
          break;
      }
    }

    private void next() {
      //move to the next image

      if (loadImages.imageIndex != loadImages.images.Count - 1) {
        loadImages.imageIndex += 1;
      } else {
        loadImages.imageIndex = 0;
      }




    }
    private void back() {
      //move to the previous image -1

      if (loadImages.imageIndex != 0) {
        loadImages.imageIndex -= 1;
      } else {
        loadImages.imageIndex = loadImages.images.Count - 1;
      }

    }
}
