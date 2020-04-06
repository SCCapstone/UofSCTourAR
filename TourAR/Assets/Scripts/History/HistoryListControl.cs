using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public static List<GameObject> buttons;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        buttons = new List<GameObject>();

        if (buttons.Count > 0) {
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        foreach (string name in HistoryList.listHistory) {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<HistoryListButton>().SetText(name);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public static void Reset() {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("HButton")) {
            Destroy(gameObj);
        }    
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
