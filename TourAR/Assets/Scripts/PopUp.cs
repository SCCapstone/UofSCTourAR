using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Popup function to make a panel of information popup onclick


public class PopUp : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPopup()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
    public void ClosePopup()
    {
        if(Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    
}
