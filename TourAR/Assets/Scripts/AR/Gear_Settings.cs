using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Settings : MonoBehaviour
{
    enum type {Button, Gear};
    [SerializeField] type objtype;

    public static int size = 0;
    public GameObject[] settings = new GameObject[size];

    [SerializeField] GameObject boxTop;
    Animator boxTopAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleSettings() {

      switch(objtype) {
        case type.Button:
          boxTopAnimator = boxTop.GetComponent<Animator>();




          break;
        case type.Gear:
          foreach (GameObject set in settings) {
            set.SetActive(!set.activeInHierarchy);
          }
          break;

        default:
          break;
      }


    }
}
