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

    //public static manageAchievements ach = manageAchievements.ac;
    //private List<manageAchievements.Achievement> achievement = manageAchievements.achievements;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ButtonListControl Start!");
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
        */      

        for (int i = 0; i < manageAchievements.achievements.Count; i++) {
            //Debug.Log("Name_index "+i+": "+ manageAchievements.achievements[i].name);

            GameObject button = Instantiate(buttonTemplate) as GameObject;
            if (manageAchievements.achievements[i].isCompleted == false) {
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(manageAchievements.achievements[i].name);
            } else {
                button.SetActive(false);
                button.GetComponent<ButtonListButton>().SetText(manageAchievements.achievements[i].description);
                button.GetComponent<ButtonListButton>().SetIcon(null);
            }
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
