using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class QuizManager : MonoBehaviour
{
    public static List<Quiz> quizzes;

    void Start()
    {
        loadQuizzes();
        Debug.Log("Quiz has been loaded");
    }

    public class Quiz
    {
        public string name;
        public string buildingID;
        public bool isCompleted;
        public bool answeredCorrectly;
        public string questionContent;
        public int correctAnswer;
        public List<string> answerOptions;
    }

    private void loadQuizzes()
    {
        // FILE IO
        Debug.Log("\n\n\n\n ****************** \n\n\n\n LOADING QUIZZES \n\n\n\n ****************** \n\n\n\n");
        if (File.Exists(Application.persistentDataPath + "/quizzes.json"))
        {
            Debug.Log("\n\n\n\n ****************** \n\n\n\n FOUND quizzes.json IN PERSISTENT STORAGE \n\n\n\n ****************** \n\n\n\n");
            string filePath = Application.persistentDataPath + "/quizzes.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                quizzes = JsonConvert.DeserializeObject<List<Quiz>>(json);
            }
        }
        else
        {
            Debug.Log("\n\n\n\n ****************** \n\n\n\n DID NOT FIND countbids.JSON IN PERSISTENT STORAGE. LOADING FROM RESOURCES \n\n\n\n ****************** \n\n\n\n");
            string json = Resources.Load<TextAsset>("JSON/quizData").text;
            quizzes = JsonConvert.DeserializeObject<List<Quiz>>(json);
        }


    }

    public List<Quiz> getQuizzes()
    {
        return quizzes;
    }

    private static void saveQuizzes()
    {
        Debug.Log("\n\n\n\n ****************** \n\n\n\n SAVING QUIZZES NOW \n\n\n\n ****************** \n\n\n\n");
        string filePath = Application.persistentDataPath + "/quizzes.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(quizzes));
    }

    public static void updateQuizResponses(string bID, bool answer)
    {
        Debug.Log("\n\n\n\n ****************** \n\n\n\n UPDATING QUIZ RESPONSES IN QUIZ MANAGER \n\n\n\n ****************** \n\n\n\n");
        for (int i = 0; i < quizzes.Count; i++)
        {
            if (quizzes[i].buildingID == bID)
            {
                quizzes[i].isCompleted = true;
                quizzes[i].answeredCorrectly = answer;
                saveQuizzes();
                break;
            }
        }
    }

}
