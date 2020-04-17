using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Toggle : MonoBehaviour
{
    public enum ARUItype {Data, Photos, Settings, Reset, Quiz, Back}; //determine which type of button this is being applied to
    [Tooltip("Determine the type of button script will be used on.")]
    [SerializeField] public ARUItype objtype;

    public static int size = 0;
    [Tooltip("State of objects will be reversed. *Not used anymore*")]
    public GameObject[] objects = new GameObject[size];

    [SerializeField] Animator boxTopAnimator, dataCanvasAnimator, picsCanvasAnimator, quizCanvasAnimator,
    dataButtonAnimator, picsButtonAnimator, resetButtonAnimator, quizButtonAnimator, backButtonAnimator,
    appTitleAnimator, stopTitleAnimator,
    dataStampAnim, picsStampAnim, resetStampAnim, quizStampAnim, backStampAnim;

    public void ToggleSettings() {

      switch(objtype) { // check for type
        //switch statements need constant checks, || is not constant
        case ARUItype.Data:
          dataStampAnim.SetTrigger("Normal");
          StartCoroutine(ARButton());
          break;

        case ARUItype.Photos:
          picsStampAnim.SetTrigger("Normal");
          StartCoroutine(ARButton());
          break;

        case ARUItype.Reset:
          resetStampAnim.SetTrigger("Normal");
          StartCoroutine(ResetButton());
          break;

        case ARUItype.Quiz:
          quizStampAnim.SetTrigger("Normal");
          StartCoroutine(QuizButton());
          break;

        case ARUItype.Back:
          backStampAnim.SetTrigger("Normal");
          StartCoroutine(BackButton());
          break;

        case ARUItype.Settings: //flips active state of all objects listed
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;
      }
    }

    IEnumerator ARButton() { //opens either info/data panel or photos panel

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

        quizButtonAnimator.SetBool("Pressed", true);
        resetButtonAnimator.SetBool("Pressed", true);
        stopTitleAnimator.SetBool("Pressed", true);

        //objects to make disappear
        dataButtonAnimator.SetBool("Pressed", true);

      } else if (objtype.Equals(ARUItype.Photos)) {

        //objects to make appear
        picsCanvasAnimator.SetBool("isOpen", true);

        quizButtonAnimator.SetBool("Pressed", true);
        resetButtonAnimator.SetBool("Pressed", true);
        stopTitleAnimator.SetBool("Pressed", true);

        //objects to make disappear
        picsButtonAnimator.SetBool("Pressed", true);

      }
    }

    IEnumerator QuizButton()  { //will only open quiz

      //remember state?

      //objects to close
      dataCanvasAnimator.SetBool("isOpen", false);
      picsCanvasAnimator.SetBool("isOpen", false);

      dataButtonAnimator.SetBool("Pressed", true);
      picsButtonAnimator.SetBool("Pressed", true);
      quizButtonAnimator.SetBool("Pressed", false);

      //objects to open
      //stoptitle and reset should already be out
      yield return new WaitForSeconds(1.0f);
      quizCanvasAnimator.SetBool("isOpen", true);
      backButtonAnimator.SetBool("Pressed", true);
    }

    IEnumerator BackButton()  { //closes quiz
      //objects to close
      quizCanvasAnimator.SetBool("isOpen", false);
      backButtonAnimator.SetBool("Pressed", false);

      //objects to open
      //remember state?
      yield return new WaitForSeconds(1.0f);
      dataCanvasAnimator.SetBool("isOpen", true);
      picsCanvasAnimator.SetBool("isOpen", true);
      quizButtonAnimator.SetBool("Pressed", true);
    }

    IEnumerator ResetButton() {
      Debug.Log("Toggle: Start Close"); 

      //objects to make disappear
      dataCanvasAnimator.SetBool("isOpen", false);
      picsCanvasAnimator.SetBool("isOpen", false);
      quizCanvasAnimator.SetBool("isOpen", false);
      stopTitleAnimator.SetBool("Pressed", false);
      quizButtonAnimator.SetBool("Pressed", false);
      backButtonAnimator.SetBool("Pressed", false);
      resetButtonAnimator.SetBool("Pressed", false);

      //objects to make appear
      dataButtonAnimator.SetBool("Pressed", false);
      picsButtonAnimator.SetBool("Pressed", false);

      //lets objects move before boxClose
      yield return new WaitForSeconds(0.5f);
      boxTopAnimator.SetBool("isOpen", false);

      //wait for box to mostly close
      yield return new WaitForSeconds(1.0f);
      appTitleAnimator.SetBool("Pressed", false);
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
