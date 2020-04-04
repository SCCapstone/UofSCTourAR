using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mapPopUp : MonoBehaviour
{


    public enum yesOrNo {Yes, No};
    [SerializeField] Animator fadeOut;
    [SerializeField] public yesOrNo button;

    public GameObject panel;

    public void onClick() {
      switch(button) { // check for type
        case yesOrNo.Yes:
            fadeOut.SetBool("Fade", false);
            WaitForAnimation(); // waits 1 sec to switch scene
            SceneManager.LoadScene("ARView");
          break;
        case yesOrNo.No:
            panel.SetActive(false);
          break;
      }
    }
    private IEnumerator WaitForAnimation()
    {
      yield return new WaitForSeconds(1);
    }
}
