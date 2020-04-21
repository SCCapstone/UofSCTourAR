using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateFields : MonoBehaviour
{

[SerializeField]
    public GameObject question;
[SerializeField]
    public GameObject button1;
[SerializeField]
    public GameObject button2;
[SerializeField]
    public GameObject button3;

Text questionText;
Text button1Text;
Text button2Text;
Text button3Text;

    // Start is called before the first frame update
    void Start()
    {
        //questionText = question.GetComponent<Text>();
        //button1Text = button1.GetComponentInChildren<Text>();
        //Debug.Log(questionText.text);
        //Debug.Log(button1Text.text);
        questionText.GetComponent<Text>().SetText(QuizManager.quiz[i].question);
        button1.GetComponentInChildren<Text>().SetText(QuizManager.quiz[i].answer1);
       //set from JSON 
       //repeat for others 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
