using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void OpenPopupAnim(Animator menuAnim)
    {
        menuAnim.SetBool("Pressed", !menuAnim.GetBool("Pressed"));
        Debug.Log("Open"+menuAnim.GetBool("Pressed"));
    }

    public void ClosePopupAnim(Animator menuAnim)
    {
        Debug.Log("Close");
        menuAnim.SetBool("Pressed", false);
        Debug.Log("Close"+menuAnim.GetBool("Pressed"));
        
    }
}
