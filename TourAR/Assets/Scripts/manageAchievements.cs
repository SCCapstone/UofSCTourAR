﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageAchievements : MonoBehaviour
{
    
    private List<Achievement> achievements;
    public string filePath = Application.dataPath + "/achievements.json";

    public manageAchievements()
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
        for(int i = 0; i < achievements.Count; i++) 
        {
            if(achievements[i].name.Equals(achievementName)) 
            {
                achievements[i].isCompleted = !achievements[i].isCompleted;
            }
        }
    }
    public void addAchievement(string aName, bool completion, string desc) 
    {
        Achievement a = new Achievement();
        a.name = aName;
        a.isCompleted = completion;
        a.description = desc;
        achievements.Insert(0, a);
    }

    public void saveAchievements() 
    {
        //THIS METHOD NEEDS TO BE CALLED TO UPDATE THE JSON FILE
        File.WriteAllText(filePath, JsonConvert.SerializeObject(achievements));
    }

    public void resetAchievements() 
    {
        //set all achievements to be uncompleted
        for(int i = 0; i < achievements.Count; i++) {
            achievements[i].isCompleted = false;
        }
    }

} 
