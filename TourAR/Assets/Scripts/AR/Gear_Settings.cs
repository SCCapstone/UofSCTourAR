using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Settings : MonoBehaviour
{
    enum type {Button, Gear};
    [SerializeField] type objtype;

    public static int size = 0;
    public GameObject[] objects = new GameObject[size];

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
        case type.Button:

          Debug.Log("Button");

          if (!boxStatus)
            boxTopAnimator.Play("BoxOpen");
          else
            boxTopAnimator.Play("BoxClose");


          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }

          Debug.Log("Objects Set");


          boxStatus = !boxStatus;


          break;
        case type.Gear:
          foreach (GameObject obj in objects) {
            obj.SetActive(!obj.activeInHierarchy);
          }
          break;

        default:
          break;
      }


    }
}
