using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search_Dropdown : MonoBehaviour
{
    List<string>
        buildings =
            new List<string>()
            { "ARView", "IBM Building", "Swearigen", "Gambrell" };

    public Dropdown dropdown;

    public Text selectedScene;

    public void Dropdown_IndexChange(int index)
    {
        selectedScene.text = buildings[index];
    }

    private void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions (buildings);
    }
}
