using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{

    [SerializeField]
    private Text myText;

    [SerializeField]
    private Image myIcon;

    [SerializeField]
    private ButtonListControl buttonControl;

    private string myTextString;

    public void SetText(string textString) {
        myTextString = textString;
        myText.text = textString;
    }

    public void SetIcon(Sprite mySprite) {
        myIcon.sprite = mySprite;
    }

    public void OnClick() {
        buttonControl.ButtonClicked(myTextString);
    }

}
