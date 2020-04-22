using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

int button1Index = 0;
int button2Index = 1;
int button3Index = 2;

    void Start()
    {
       populateQandA();
    }

    public void populateQandA() {
        for (int i = 0; i < QuizManager.quizzes.Count; i++) {
             if (QuizManager.quizzes[i].buildingID == loadTourStops.stopToLoad) {

                questionText = question.GetComponent<Text>();
                questionText.text = "<b>" + QuizManager.quizzes[i].questionContent + "</b>";

                button1Text = button1.GetComponentInChildren<Text>();
                button1Text.text = QuizManager.quizzes[i].answerOptions[0];

                button2Text = button2.GetComponentInChildren<Text>();
                button2Text.text = QuizManager.quizzes[i].answerOptions[1];

                button3Text = button3.GetComponentInChildren<Text>();
                button3Text.text = QuizManager.quizzes[i].answerOptions[2];
             }
        }
    }

    public void checkResponse() {
        //if this button clicked has the same index number as the 
        //correct index in the correct answer of json mark as correct in json
        //mark as completed in json regardless
        for (int i = 0; i < QuizManager.quizzes.Count; i++) {
            if (QuizManager.quizzes[i].buildingID == loadTourStops.stopToLoad) {
                int buttonName = int.Parse(EventSystem.current.currentSelectedGameObject.name);
                Vector4 buttonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
                if (buttonName == QuizManager.quizzes[i].correctAnswer) {
                    QuizManager.quizzes[i].answeredCorrectly = true;
                    buttonColor[0] = 0;
                    buttonColor[2] = 0;
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = buttonColor;
                } else {
                    buttonColor[1] = 0;
                    buttonColor[2] = 0;
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = buttonColor;
                }
                QuizManager.quizzes[0].isCompleted = true;
                //TODO: prevent quiz interaction unless reset
                //Debug.Log(QuizManager.quizzes[i].answeredCorrectly);
                //Debug.Log(QuizManager.quizzes[i].isCompleted);
            }
        }
    }
}
