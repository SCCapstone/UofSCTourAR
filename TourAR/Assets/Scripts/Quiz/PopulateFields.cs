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

    void Start()
    {
        populateQandA();
    }

    public void populateQandA()
    {
        Debug.Log("\n\n\n\n ****************** \n\n\n\n IN populateQandA() \n\n\n\n ****************** \n\n\n\n");
        // This is just initialization of the quiz
        for (int i = 0; i < QuizManager.quizzes.Count; i++)
        {
            if (QuizManager.quizzes[i].buildingID == loadTourStops.stopToLoad)
            {
                questionText = question.GetComponent<Text>();
                questionText.text = "<b>" + QuizManager.quizzes[i].questionContent + "</b>"; //populate the text
                Debug.Log("Quiz Question: " + questionText.text);

                button1Text = button1.GetComponentInChildren<Text>(); //assign itself to the correct object
                button1Text.text = QuizManager.quizzes[i].answerOptions[0]; //populate the text
                Debug.Log("Quiz Button 1: " + button1Text.text);

                button2Text = button2.GetComponentInChildren<Text>(); //assign itself to the correct object
                button2Text.text = QuizManager.quizzes[i].answerOptions[1]; //populate the text
                Debug.Log("Quiz Button 2: " + button1Text.text);


                button3Text = button3.GetComponentInChildren<Text>(); //assign itself to the correct object
                button3Text.text = QuizManager.quizzes[i].answerOptions[2]; //populate the text
                Debug.Log("Quiz Button 3: " + button1Text.text);

                if (QuizManager.quizzes[i].isCompleted)
                {
                    //if quiz has been taken before.
                    button1.GetComponent<Button>().enabled = false;
                    button2.GetComponent<Button>().enabled = false;
                    button3.GetComponent<Button>().enabled = false;
                    Debug.Log("\n\n\n\n ****************** \n\n\n\n IN QUIZ COMPLETED OF populateQandA() \n\n\n\n ****************** \n\n\n\n");
                    if (QuizManager.quizzes[i].correctAnswer == 0)
                    {
                        Debug.Log("\n\n\n\n ****************** \n\n\n\n BUTTON 1 WAS CORRECT \n\n\n\n ****************** \n\n\n\n");
                        Vector4 buttonColor = button1.GetComponent<Image>().color;
                        buttonColor[0] = 0;
                        buttonColor[1] = 1;
                        buttonColor[2] = 0;
                        buttonColor[3] = 0.686f;
                        button1.GetComponent<Image>().color = buttonColor;
                    }
                    else if (QuizManager.quizzes[i].correctAnswer == 1)
                    {
                        Debug.Log("\n\n\n\n ****************** \n\n\n\n BUTTON 2 WAS CORRECT \n\n\n\n ****************** \n\n\n\n");
                        Vector4 buttonColor = button2.GetComponent<Image>().color;
                        buttonColor[0] = 0;
                        buttonColor[1] = 1;
                        buttonColor[2] = 0;
                        buttonColor[3] = 0.686f;
                        button2.GetComponent<Image>().color = buttonColor;
                    }
                    else
                    {
                        Debug.Log("\n\n\n\n ****************** \n\n\n\n BUTTON 3 WAS CORRECT \n\n\n\n ****************** \n\n\n\n");
                        Vector4 buttonColor = button3.GetComponent<Image>().color;
                        buttonColor[0] = 0;
                        buttonColor[1] = 1;
                        buttonColor[2] = 0;
                        buttonColor[3] = 0.686f;
                        button3.GetComponent<Image>().color = buttonColor;
                    }
                }
            }
        }
    }

    public void checkResponse()
    {
        //if this button clicked has the same index number as the
        //correct index in the correct answer of json mark as correct in json
        //mark as completed in json regardless

        // This method is called when the user responds to the quiz!
        Debug.Log("\n\n\n\n ****************** \n\n\n\n IN checkResponse() \n\n\n\n ****************** \n\n\n\n");
        for (int i = 0; i < QuizManager.quizzes.Count; i++)
        {
            if (QuizManager.quizzes[i].buildingID == loadTourStops.stopToLoad)
            {
                int buttonName = int.Parse(EventSystem.current.currentSelectedGameObject.name);
                Vector4 buttonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;

                button1.GetComponent<Button>().enabled = false;
                button2.GetComponent<Button>().enabled = false;
                button3.GetComponent<Button>().enabled = false;

                if (buttonName == QuizManager.quizzes[i].correctAnswer) // if they ansered correctly
                {
                    QuizManager.quizzes[i].answeredCorrectly = true;
                    buttonColor[0] = 0;
                    buttonColor[1] = 1;
                    buttonColor[2] = 0;
                    buttonColor[3] = 0.686f;
                    QuizManager.updateQuizResponses(loadTourStops.stopToLoad, true);
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = buttonColor;
                }
                else
                {
                    buttonColor[0] = 1;
                    buttonColor[1] = 0;
                    buttonColor[2] = 0;
                    buttonColor[3] = 0.686f;
                    QuizManager.updateQuizResponses(loadTourStops.stopToLoad, false);
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = buttonColor;
                }
            }
        }
    }
}
