using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mapPopUp : MonoBehaviour
{


    public enum yesOrNo {Yes, No};
    [SerializeField] public yesOrNo button;

    public GameObject panel;

    public void onClick() {
      switch(button) { // check for type
        case yesOrNo.Yes:
            SceneManager.LoadScene("ARView");
          break;
        case yesOrNo.No:
            panel.SetActive(false);
          break;
      }
    }
}
