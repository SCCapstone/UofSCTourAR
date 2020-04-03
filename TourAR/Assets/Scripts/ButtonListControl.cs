using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private int[] intArray;

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

        foreach (int i in intArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText(""); //This is where the button text is set. For example: .setText("Secret\n Achievement\n #" + i)
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString) {
        Debug.Log(myTextString);
    }
}
