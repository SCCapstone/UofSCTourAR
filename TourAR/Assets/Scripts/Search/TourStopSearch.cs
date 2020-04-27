using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TourStopSearch : MonoBehaviour
{
    public InputField inField;

    GameObject[] obj;
    [SerializeField] GameObject buttonParent;
    // Start is called before the first frame update
    void Start()
    {
        //Set gameobject list
        obj = GameObject.FindGameObjectsWithTag("SearchText");
    }

    public void ShowHideButtons(GameObject[] stops)
    {
            /*
            foreach (Button objText in stops)
            {
                //Unhide every button
                objText.gameObject.SetActive(true);
            }*/
            //Debug.Log("Show");
            

            foreach (GameObject ts in stops)
            {
                Text objText = ts.GetComponent<Text>();
                if (objText.text.ToLower().Contains(inField.text.ToLower()))
                {
                    ts.transform.parent.gameObject.SetActive(true);
                }
                else
                {
                    ts.transform.parent.gameObject.SetActive(false);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (obj != null && obj.Length > 0) {
            ShowHideButtons(obj);
        } else {
            Debug.Log("Waiting for search to initialize");
            obj = GameObject.FindGameObjectsWithTag("SearchText");
        }
    }
}
