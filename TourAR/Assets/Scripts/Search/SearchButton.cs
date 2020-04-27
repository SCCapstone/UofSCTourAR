using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchButton : MonoBehaviour
{
    [SerializeField] public Text myText;
    [SerializeField] public string buildingID;

    [SerializeField]
    private SearchButtonControl buttonControl;

    public void setInfo(string name, string bID) {
        myText.text = name;
        buildingID = bID;
    }

    public void OnClick()
    {
        buttonControl.ButtonClicked (myText.text);
    }
}
