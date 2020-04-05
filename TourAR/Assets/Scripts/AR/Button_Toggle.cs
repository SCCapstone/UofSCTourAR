using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Toggle : MonoBehaviour
{
    public enum ARUItype {Data, Photos, Settings, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ARUItype objtype;

    public static int size = 0;
    [Tooltip("State of objects will be reversed.")]
    public GameObject[] objects = new GameObject[size];

    public static int trueObjectsSize = 0;
    [Tooltip("Set all objects to True.")]
    public GameObject[] trueObjects = new GameObject[trueObjectsSize];

    public static int falseObjectsSize = 0;
    [Tooltip("Set all objects to False. Make sure self is in the last spot in the array")]
    public GameObject[] falseObjects = new GameObject[falseObjectsSize];


    [SerializeField] Animator boxTopAnimator;
    [SerializeField] Animator dataCanvasAnimator;
    [SerializeField] Animator picsCanvasAnimator;

    //private bool boxStatus = false;

    // Start is called before the first frame update
    void Start()
    {
      //boxTopAnimator = boxTop.GetComponent<Animator>();
      //dataCanvasAnimator = dataCanvas.GetComponent<Animator>();
      //picsCanvasAnimator = picsCanvas.GetComponent<Animator>();
      //boxStatus = boxTopAnimator.GetBool("isOpen");
      //boxTopAnimator.SetBool("isOpen", false); //initialize box as closed so animation doesnt trigger on spawn

    }
    void Update() {
      //boxStatus = removed boxStatus
    }

    public void ToggleSettings() {

      switch(objtype) { // check for type
        case ARUItype.Data:
            ARButton();
          break;

        case ARUItype.Photos:
            ARButton();
          break;

        case ARUItype.Settings: //flips active state of all objects listed
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;

        case ARUItype.Back:
          BackButton();
          break;
      }


    }

    private void ARButton() {
      if (!boxTopAnimator.GetBool("isOpen")) { // boxStatus will be false here on initialization
        boxTopAnimator.SetBool("isOpen", true);
      } else {
        Debug.Log("Toggle: Box is already open - "+ boxTopAnimator.GetBool("isOpen"));
      }
      //fade button out
      //Animator buttonAnim = gameObject.GetComponentInParent<Animator>();
      //buttonAnim.SetBool("Fade", true);
      //start canvas anim
      
      DelayAnimCoroutineLong();//waits for box to open
      
      Debug.Log("Check type");
      //once objects are active start animations
      if (objtype.Equals(ARUItype.Data)) {
        Debug.Log("Anim for data is set to true");
        dataCanvasAnimator.SetBool("isOpen", true);
        Debug.Log("AnimData "+dataCanvasAnimator.GetBool("isOpen"));

      } else if (objtype.Equals(ARUItype.Photos)) {
        Debug.Log("Anim for pics is set to true");
        picsCanvasAnimator.SetBool("isOpen", true);
        Debug.Log("AnimPics "+picsCanvasAnimator.GetBool("isOpen"));

      }
      PrintState();
      DelayAnimCoroutineLong(); //waits for anims to complete for canvas before bringing in title

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
    }

    private void BackButton() {
      Debug.Log("Toggle: Start Close"); 
      dataCanvasAnimator.SetBool("isOpen", false);
      picsCanvasAnimator.SetBool("isOpen", false);
      //DelayAnimCoroutineLong(); //lets canvases close before boxClose
      DelayAnimCoroutine();
      boxTopAnimator.SetBool("isOpen", false);

      //Debug.Log("Toggle_BoxClose: " + boxTopAnimator.GetBool("isOpen"));
      //boxStatus = boxTopAnimator.GetBool("isOpen");
      PrintState();

      DelayAnimCoroutineLong();

      foreach (GameObject t in trueObjects) {
        t.SetActive(true);
        //TODO implement animations for every object, should look somthing like:
        //t.GetComponent<Animator>().SetBool("FadeIn", true);
      }
      foreach (GameObject f in falseObjects) {
        if (f.name.Contains("Button")) {
          DelayAnimCoroutine();
          DelayAnimCoroutineLong();
          Debug.Log("Closed button "+f.name);
          f.SetActive(false);
        } else {
          f.SetActive(false);
        }
      }
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

    IEnumerator DelayAnimCoroutine() {
      yield return new WaitForSeconds(1.0f);
      Debug.Log("Waiting.....");
    }
    IEnumerator DelayAnimCoroutineLong() {
      yield return new WaitForSeconds(2.5f);
      Debug.Log("Waiting.....");
    }
}
