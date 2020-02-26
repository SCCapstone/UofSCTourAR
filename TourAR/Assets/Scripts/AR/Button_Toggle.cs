using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Toggle : MonoBehaviour
{
    public enum ARUItype {ARButton, Settings, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ARUItype objtype;

    public static int size = 0;
    [Tooltip("State of objects will be reversed.")]
    public GameObject[] objects = new GameObject[size];

    public static int trueObjectsSize = 0;
    [Tooltip("Set all objects to True.")]
    public GameObject[] trueObjects = new GameObject[trueObjectsSize];

    public static int falseObjectsSize = 0;
    [Tooltip("Set all objects to False.")]
    public GameObject[] falseObjects = new GameObject[falseObjectsSize];


    [SerializeField] GameObject boxTop;
    private Animator boxTopAnimator;
    //private bool boxStatus = false;

    // Start is called before the first frame update
    void Start()
    {
      boxTopAnimator = boxTop.GetComponent<Animator>();
      //boxStatus = boxTopAnimator.GetBool("isOpen");
      //boxTopAnimator.SetBool("isOpen", false); //initialize box as closed so animation doesnt trigger on spawn

    }
    void Update() {
      //boxStatus = removed boxStatus
    }

    public void ToggleSettings() {

      switch(objtype) { // check for type
        case ARUItype.ARButton:
            ARButton();
          break;

        case ARUItype.Settings:
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;

        case ARUItype.Back:
          BackButton();
          break;

        default:
          //Debug.Log("DefaultCase_Toggle");
          break;
      }


    }

    private void ARButton() {
      if (!boxTopAnimator.GetBool("isOpen")) { // boxStatus will be false here on initialization
        //boxTopAnimator.Play("BoxOpen"); //TODO does not work...
        boxTopAnimator.SetBool("isOpen", true);
        Debug.Log("Toggle_BoxOpen: "+ boxTopAnimator.GetBool("isOpen"));
        PrintState();
        //boxStatus = boxTopAnimator.GetBool("isOpen");
      }
      else {
        //boxTopAnimator.Play("BoxClose");
        //boxTopAnimator.SetBool("isOpen", false);
        Debug.Log("Toggle "+"Box is already open: " + boxTopAnimator.GetBool("isOpen"));
        PrintState();

      }

      foreach (GameObject obj in objects) { //set all objects to opposite what they are currently
        obj.SetActive(!obj.activeInHierarchy);
      }
      foreach (GameObject t in trueObjects) {
        t.SetActive(true);
        Debug.Log("Toggle "+t.name+ " is "+t.activeInHierarchy);
      }
      foreach (GameObject f in falseObjects) {
        f.SetActive(false);
        Debug.Log("Toggle "+f.name+ " is "+f.activeInHierarchy);
      }
    }

    private void BackButton() {
      boxTopAnimator.SetBool("isOpen", false);
      Debug.Log("Toggle_BoxClose: " + boxTopAnimator.GetBool("isOpen"));
      //boxStatus = boxTopAnimator.GetBool("isOpen");
      PrintState();

      foreach (GameObject t in trueObjects) {
        t.SetActive(true);
        //TODO implement animations for every object, should look somthing like:
        //t.GetComponent<Animator>().SetBool("FadeIn", true);
      }
      foreach (GameObject f in falseObjects) {
        f.SetActive(false);
      }
    }

    private void PrintState() {
      string[] states = new string[]{"Idle_State", "Open", "Close"};

      foreach (string state in states) { //find the matching name of the state the animator is in and print
        if (boxTopAnimator.GetCurrentAnimatorStateInfo(0).IsName(state)) {
            Debug.Log("Toggle_ The current anim state is: "+state);
        }
      }
      Debug.Log("Toggle_state: " + boxTopAnimator.GetBool("isOpen"));

    }
}
