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
            if (!achievementScore.countbids.Contains(loadTourStops.stopToLoad)) {
                achievementScore.countbids.Add(loadTourStops.stopToLoad);
            }
            SceneManager.LoadScene("ARView");
          break;
        case yesOrNo.No:
            panel.SetActive(false);
          break;
      }
    }
}
