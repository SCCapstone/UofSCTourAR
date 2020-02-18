using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Settings : MonoBehaviour
{
    public enum ARUItype {Button, Gear, Back};
    [SerializeField] public ARUItype objtype;

    public static int size = 0;
    public GameObject[] objects = new GameObject[size];
    public static int back_size = 0;
    public GameObject[] back_objects = new GameObject[back_size];


    //[SerializeField] GameObject boxTop;
    [SerializeField] Animator boxTopAnimator;
    private bool boxStatus = false;

    // Start is called before the first frame update
    void Start()
    {
      boxTopAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleSettings() {

      Debug.Log("Toggle");


      switch(objtype) {
        case ARUItype.Button:

          Debug.Log("Button");

          if (!boxStatus) {
            boxTopAnimator.Play("BoxOpen");
            Debug.Log("Toggle_BoxOpen");
          }
          else {
            boxTopAnimator.Play("BoxClose");
            Debug.Log("Toggle_BoxClose");

          }

          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }

          boxStatus = !boxStatus;


          break;

        case ARUItype.Gear:
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;

        case ARUItype.Back:
          foreach (GameObject obj in objects) {
            obj.SetActive(false);
          }

          foreach (GameObject back in back_objects) {
            back.SetActive(true);
          }

          boxTopAnimator.Play("BoxClose");
          Debug.Log("Toggle_BoxClose");

          boxStatus = !boxStatus;

          break;

        default:
          Debug.Log("DefaultCase_Toggle");
          break;
      }


    }
}
