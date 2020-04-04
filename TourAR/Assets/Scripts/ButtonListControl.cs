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

    public static manageAchievements ach = new manageAchievements();
    private List<manageAchievements.Achievement> achievement = ach.getAchievements();

    // Start is called before the first frame update
    void Start()
    {
/* 
        Debug.Log(ach);
        Debug.Log(achieve);

        buttons = new List<GameObject>();

        if (buttons.Count > 0) {
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        for (int i = 0; i < achieve.Count; i++) {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            if (achieve[i].isCompleted == false) {
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(achieve[i].name);ç
            } else {
                button.SetActive(false);
                button.GetComponent<ButtonListButton>().SetText(achieve[i].description);
                button.GetComponent<ButtonListButton>().SetIcon(null);
            }
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
*/
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
