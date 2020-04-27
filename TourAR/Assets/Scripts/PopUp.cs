using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Popup function to make a panel of information popup onclick
public class PopUp : MonoBehaviour
{
    public GameObject Panel;

    [SerializeField] Image iconObj;

    public void OpenPopup()
    {

        
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    public void ClosePopup()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    public void lockedPopup()
    {

        if (iconObj.sprite.name == "lock" && Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    public void setSearchPopup() {
        Debug.Log(loadTourStops.stopToLoad);
        Debug.Log(gameObject.GetComponent<SearchButton>().buildingID);
        loadTourStops.stopToLoad = gameObject.GetComponent<SearchButton>().buildingID;
        Panel.SetActive(true);
    }
    public void setHistoryPopup() {
        Debug.Log(loadTourStops.stopToLoad);
        Debug.Log(gameObject.GetComponent<HistoryListButton>().buildingID);
        loadTourStops.stopToLoad = gameObject.GetComponent<HistoryListButton>().buildingID;
        Panel.SetActive(true);
    }
}
