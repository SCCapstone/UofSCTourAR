using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryListButton : MonoBehaviour
{
    [SerializeField]
    private Text myText;

    [SerializeField]
    private HistoryListControl buttonControl;

    private string myTextString;
    [SerializeField] public string buildingID;


    public void SetText(string textString)
    {
        myTextString = textString;
        myText.text = textString;
    }

    public void setInfo(string name, string bID) {
        myText.text = name;
        buildingID = bID;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked (myTextString);
    }

    public void Reset()
    {
        Destroy (gameObject);
    }
}
