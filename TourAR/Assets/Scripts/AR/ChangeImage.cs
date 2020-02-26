using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{

    public enum ButtonType {Next, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ButtonType button;

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
      Debug.Log("Next");
      //move to the next image

      if (loadImages.imageIndex != loadImages.images.Count - 1) {
        loadImages.imageIndex += 1;
      } else {
        loadImages.imageIndex = 0;
      }

    }
    private void back() {
      Debug.Log("Back");

      //move to the previous image -1

      if (loadImages.imageIndex != 0) {
        loadImages.imageIndex -= 1;
      } else {
        loadImages.imageIndex = loadImages.images.Count - 1;
      }

    }
}
