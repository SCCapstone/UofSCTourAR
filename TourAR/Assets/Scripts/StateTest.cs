using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateTest : MonoBehaviour
{
    [SerializeField]
    Text text;

    [SerializeField]
    Animator anim;

    string[] states = new string[] { "Closed, BoxOpening, Open, BoxClosing" };

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("StateText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string state in states)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(state))
            {
                text.text = "State: " + state;
                Debug.Log("State: " + state);
            }
        }
    }
}
