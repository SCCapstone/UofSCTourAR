using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TourStopSearch : MonoBehaviour
{
    public InputField inField;

    public List<Button> tourstops = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ShowHideButtons(List<Button> stops)
    {
            foreach (Button ts in stops)
            {
                //Unhide every button
                ts.gameObject.SetActive(true);
            }

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

    // Update is called once per frame
    void Update()
    {
        ShowHideButtons (tourstops);
    }
}
