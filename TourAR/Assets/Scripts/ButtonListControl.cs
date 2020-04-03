using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{

    public class Achievement
    {
        public string name;
        public int condition;
        public bool isCompleted;
        public string description;
    }

    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private Sprite[] iconSprites;

    [SerializeField]
    private int[] intArray;
    
    public static manageAchievements ach = new manageAchievements();
    private List<Achievement> achievement = ach.getAchievements();

    private List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>();

        if (buttons.Count > 0) {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        for (int i = 0; i < achievement.Count; i++)
        { //set if else here for display if achievement is completed
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            //button.GetComponent<ButtonListButton>().SetIcon(null);
            button.GetComponent<ButtonListButton>().SetText(i.name); //This is where the button text is set. For example: .setText("Secret\n Achievement\n #" + i)
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    
}
