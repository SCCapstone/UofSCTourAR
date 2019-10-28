using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneOnClick(string sceneName) //scene name param
    {
        SceneManager.LoadScene(sceneName); //will switch to scene on click
    } 
}
