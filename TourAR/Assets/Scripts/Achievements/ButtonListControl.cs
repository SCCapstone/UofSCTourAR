using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private Sprite[] iconSprites;

    private List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>();

        if (buttons.Count > 0) {
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        for (int i = 0; i < manageAchievements.achievements.Count; i++) {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            if (manageAchievements.achievements[i].isCompleted == false) {
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(manageAchievements.achievements[i].name);
                button.GetComponent<ButtonListButton>().SetIcon(iconSprites[0]);
            } else {
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(manageAchievements.achievements[i].description);
                button.GetComponent<ButtonListButton>().SetIcon(iconSprites[1]);
            }
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
