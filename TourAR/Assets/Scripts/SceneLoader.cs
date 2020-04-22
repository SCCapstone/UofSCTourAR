using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        
    }

    public void SceneChange(string sceneName)
    {   
        
        SceneManager.LoadScene (sceneName);
    }
}
