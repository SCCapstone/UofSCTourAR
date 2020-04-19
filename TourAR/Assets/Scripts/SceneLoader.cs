using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Only used to fadeOut of the ARView when navigating back to Map")]
    public bool fade = false;

    [SerializeField]
    Animator animator;

    void Start()
    {
        if (fade)
        {
            animator.SetBool("Fade", true);
        }
    }

    public void SceneChange(string sceneName)
    {
        if (fade)
        {
            animator.SetBool("Fade", false);
        }
        SceneManager.LoadScene (sceneName);
    }
}
