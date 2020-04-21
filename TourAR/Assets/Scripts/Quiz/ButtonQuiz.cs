using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuiz : MonoBehaviour
{

    [SerializeField]
    private Text myText;

    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;

    public void SetText(string textString) {
        myTextString = textString;
        myText.text = textString;
    }
 
    public void OnClick() {
        buttonControl.ButtonClicked(myTextString);
    }

}