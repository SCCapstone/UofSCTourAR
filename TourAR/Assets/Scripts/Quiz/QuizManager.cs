﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class QuizManager : MonoBehaviour
{

    //public static List<string> answerOptions = new List<string>();

    void Start()
    {
        loadQuizzes();
        checkIfCompleted();
        question = GetComponent<Text>();
    }

    public class Quizzes
    {
        public string stopName;
        public string question;
        public bool isCompleted;
        public int correctAnswer;
        public bool answeredCorrectly;
        public string buildingID;
        public List<string> answerOptions;
    }

    private void loadQuizzes()
    {
        // JUST FILE IO
        string json = Resources.Load<TextAsset>("JSON/quizData").text;
        quizzes = JsonConvert.DeserializeObject<List<Quizzes>>(json);
    }

    public void newQuiz(string aName, bool completed, int correctAns, bool answeredRight, string questionData,
    string building, List<string> ansOps) {
        Quizzes q = new Quizzes();
        stopName = aName;
        isCompleted = completed;
        correctAnswer = correctAns;
        answeredCorrectly = answeredRight;
        question = questionData;
        buildingID = building;
        answerOptions = ansOps;

    }

    /*public void populateQuestion(string name) {
        for (int i = 0; i < quizzes.Count; i++) {
            if(quizzes[i].stopName.Equals(name)) {
                question.text = questionContent;
            }
        }
    }*/

   /* public void toggleAchievementStatus(string achievementName)
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].name.Equals(achievementName))
            {
                achievements[i].isCompleted = !achievements[i].isCompleted;
            }
        }
        saveAchievements();
    }*/

    /*public void checkIfCompleted() {
        for (int i = 0; i < achievements.Count; i++) {
            if (achievementScore.countbids.Count >= achievements[i].condition) {
                achievements[i].isCompleted = true;
            }
        }
        saveAchievements();
    }*/

    public void saveQuizzes()
    {
        
    }

    public void resetAchievements()
    {
        //set all achievements to be uncompleted
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].isCompleted = false;
        }
    }

}
