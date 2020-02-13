﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageAchievements : MonoBehaviour
{
    
    private List<Achievement> achievements;

    // Start is called before the first frame update
    void Start()
    {
        loadAchievements();
    }

    public class Achievement
    {
        public string name;
        public bool isCompleted;
        public string description;
    }

    private void loadAchievements()
    {
        /*
            Application.dataPath is required because it is the only way to ensure that we are accessing our assets folder,
            on both desktop runs and mobile. 
        */
        string filePath = Application.dataPath + "/achievements.json";
        
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            achievements = JsonConvert.DeserializeObject<List<Achievement>>(json);
        }

    }

    public List<Achievement> getAchievements()
    {
        return achievements;
    }

    public void toggleAchievementStatus(string achievementName)
    {
        //TODO add functionality
    }

}