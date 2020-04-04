using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TourStopSearch : MonoBehaviour
{

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowHideButtons(tourstops);
    }

    public InputField inField;

    public List<Button> tourstops = new List<Button>();

    public void ShowHideButtons(List<Button> stops)
    {
        if (inField.text == null)
        {
            foreach (Button ts in stops)
            {
                //Unhide every button
                ts.gameObject.SetActive(true);
            }
        }

        //user starts typing
        else
        {
            foreach (Button ts in stops)
            {
                if (ts.name.ToLower().Contains(inField.text.ToLower()))
                {
                    ts.gameObject.SetActive(true);
                }

                else
                {
                    ts.gameObject.SetActive(false);
                }
            }
        }
    }



}
