using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARButton_ShowText : MonoBehaviour
{

    //public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Toggle() {
      //text.gameObject.SetActive(!text.gameObject.activeSelf);
    }


    public void SetImage(GameObject image) {
      image.SetActive(!image.activeInHierarchy);
    }
}
