using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openHyperlinks : MonoBehaviour
{

    public void OpenHorseshoe()
    {
        Application.OpenURL("https://sc.edu/about/our_history/horseshoe_history/index.php");
    }

    public void OpenCampusBuildings()
    {
        Application.OpenURL("https://www.sc.edu/about/offices_and_divisions/student_affairs/our_facilities/index.php");
    }

    public void OpenInstSite()
    {
        Application.OpenURL("https://sc.edu/");
    }
    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
