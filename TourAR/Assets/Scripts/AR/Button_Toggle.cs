using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Toggle : MonoBehaviour
{
    public enum ARUItype {Data, Photos, Settings, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ARUItype objtype;

    public static int size = 0;
    [Tooltip("State of objects will be reversed. *Not used anymore*")]
    public GameObject[] objects = new GameObject[size];
    /*
    public static int trueObjectsSize = 0;
    [Tooltip("Set all objects to True.")]
    public GameObject[] trueObjects = new GameObject[trueObjectsSize];

    public static int falseObjectsSize = 0;
    [Tooltip("Set all objects to False. Make sure self is in the last spot in the array")]
    public GameObject[] falseObjects = new GameObject[falseObjectsSize];
    */

    [SerializeField] Animator boxTopAnimator, dataCanvasAnimator, picsCanvasAnimator, dataButtonAnimator,
    picsButtonAnimator, backButtonAnimator, appTitleAnimator, stopTitleAnimator;

    public void ToggleSettings() {

      switch(objtype) { // check for type
        //switch statements need constant checks, || is not constant
        case ARUItype.Data:
            StartCoroutine(ARButton());
          break;

        case ARUItype.Photos:
            StartCoroutine(ARButton());
          break;

        case ARUItype.Settings: //flips active state of all objects listed
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;

        case ARUItype.Back:
          StartCoroutine(BackButton());
          break;
      }
    }

    IEnumerator ARButton() {
      //check if box is open
      if (!boxTopAnimator.GetBool("isOpen")) {
        boxTopAnimator.SetBool("isOpen", true);
        appTitleAnimator.SetBool("Pressed", true);
        yield return new WaitForSeconds(1.25f);
      } else {
        Debug.Log("Toggle: Box is already open - "+ boxTopAnimator.GetBool("isOpen"));
      }
    
      if (objtype.Equals(ARUItype.Data)) {

        //objects to make appear
        dataCanvasAnimator.SetBool("isOpen", true);
        backButtonAnimator.SetBool("Pressed", true);
        stopTitleAnimator.SetBool("Pressed", true);

        //objects to make disappear
        dataButtonAnimator.SetBool("Pressed", true);

      } else if (objtype.Equals(ARUItype.Photos)) {

        //objects to make appear
        picsCanvasAnimator.SetBool("isOpen", true);
        backButtonAnimator.SetBool("Pressed", true);
        stopTitleAnimator.SetBool("Pressed", true);

        //objects to make disappear
        appTitleAnimator.SetBool("Pressed", true);
        picsButtonAnimator.SetBool("Pressed", true);

      }

      /*
      PrintState();
      yield return new WaitForSeconds(0.5f); //waits for anims to complete for canvas before bringing in title

      foreach (GameObject obj in objects) { //set all objects to opposite what they are currently
        obj.SetActive(!obj.activeInHierarchy);
      }
      foreach (GameObject t in trueObjects) {
        t.SetActive(true);
        Debug.Log("Toggle "+t.name+ " is "+t.activeInHierarchy);
      }
      foreach (GameObject f in falseObjects) {
        if (f.name.Contains("Button")) {
          //DelayAnimCoroutine();
          //DelayAnimCoroutineLong();
          f.SetActive(false);
        } else {
          f.SetActive(false);
        }
        Debug.Log("Toggle "+f.name+ " is "+f.activeInHierarchy);
      }
      */
    }

    IEnumerator BackButton() {
      Debug.Log("Toggle: Start Close"); 

      //objects to make disappear
      dataCanvasAnimator.SetBool("isOpen", false);
      picsCanvasAnimator.SetBool("isOpen", false);
      stopTitleAnimator.SetBool("Pressed", false);
      backButtonAnimator.SetBool("Pressed", false);

      //objects to make appear
      dataButtonAnimator.SetBool("Pressed", false);
      picsButtonAnimator.SetBool("Pressed", false);

      //lets objects move before boxClose
      yield return new WaitForSeconds(0.5f);
      boxTopAnimator.SetBool("isOpen", false);

      //wait for box to mostly close
      yield return new WaitForSeconds(1.0f);
      appTitleAnimator.SetBool("Pressed", false);

      /*
      yield return new WaitForSeconds(1.0f);

      foreach (GameObject t in trueObjects) {
        t.SetActive(true);
      }
      foreach (GameObject f in falseObjects) {
        if (f.name.Contains("Button")) {
          Debug.Log("Closed button "+f.name);
          f.SetActive(false);
        } else {
          f.SetActive(false);
        }
      }*/
    }

    private void PrintState() { //Prints the bool state true/false and current state name
      Debug.Log("Toggle_BoxTop: " + boxTopAnimator.GetBool("isOpen"));
      PrintStateName(boxTopAnimator, "BoxTop");

      Debug.Log("Toggle_Data: " + dataCanvasAnimator.GetBool("isOpen"));
      PrintStateName(dataCanvasAnimator, "Data");

      Debug.Log("Toggle_Photos: " + picsCanvasAnimator.GetBool("isOpen"));
      PrintStateName(picsCanvasAnimator, "Pics");
    }
    private void PrintStateName(Animator anim, string name) {
      string[] states = new string[]{"Idle_State", "Open", "Close", "Move UI Out", "Move UI In"};

      foreach (string state in states) { //find the matching name of the state the animator is in and print
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(state)) {
            Debug.Log("Toggle_ The current " + name + " anim state is: "+state);
        }
      }
    }
}
