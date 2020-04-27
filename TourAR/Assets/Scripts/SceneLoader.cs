using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static string previousScene = "Map";

    public void SceneChange(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }

    public void SceneChangeAR(string currScene) {
        previousScene = currScene;
        SceneManager.LoadScene("ARView");
    }
    public void BackFromAR() {
        SceneManager.LoadScene(previousScene);
    }
}
