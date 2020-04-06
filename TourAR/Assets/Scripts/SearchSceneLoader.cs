using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SearchSceneLoader : MonoBehaviour
{
    [SerializeField]
    private InputField inField;

    private void Start() {
        GetComponent<Button>().onClick.AddListener(TryLoadScene);
    }

    private void TryLoadScene() {
        string sceneName = inField.text;
        if (SceneExists(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public bool SceneExists(string name)
    {
        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        return scenesInBuild.Any(t => t == name);
    }

}
