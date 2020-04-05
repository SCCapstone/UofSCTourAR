using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    private List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("goodbye");
        buttons = new List<GameObject>();

        if (buttons.Count > 0) {
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }
        Debug.Log("goodbye2");

        foreach (string name in HistoryList.listHistory) {
            Debug.Log("button loop");
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText(name);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
