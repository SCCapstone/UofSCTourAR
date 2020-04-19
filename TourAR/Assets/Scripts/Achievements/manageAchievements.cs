using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class manageAchievements : MonoBehaviour
{
    public static List<Achievement> achievements;

    void Start()
    {
        loadAchievements();
        checkIfCompleted();
    }

    public class Achievement
    {
        public string name;

        public int condition;

        public bool isCompleted;

        public string description;
    }

    public void loadAchievements()
    {
        Debug
            .Log("\n\n\n\n ****************** \n\n\n\n LOADING ACHIEVEMENTS \n\n\n\n ****************** \n\n\n\n");
        if (File.Exists(Application.persistentDataPath + "/achievements.json"))
        {
            Debug
                .Log("\n\n\n\n ****************** \n\n\n\n FOUND achievements.json IN PERSISTENT STORAGE \n\n\n\n ****************** \n\n\n\n");
            string filePath =
                Application.persistentDataPath + "/achievements.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                achievements =
                    JsonConvert.DeserializeObject<List<Achievement>>(json);
            }
        }
        else
        {
            Debug
                .Log("\n\n\n\n ****************** \n\n\n\n DID NOT FIND achievements.JSON IN PERSISTENT STORAGE \n\n\n\n ****************** \n\n\n\n");
            string json = Resources.Load<TextAsset>("JSON/achievements").text;
            achievements =
                JsonConvert.DeserializeObject<List<Achievement>>(json);
        }
    }

    public bool getAchievementStatus(int index)
    {
        if (index < achievements.Count)
        {
            return achievements[index].isCompleted;
        }
        return false;
    }

    public List<Achievement> getAchievements()
    {
        return achievements;
    }

    public void toggleAchievementStatus(string achievementName)
    {
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievements[i].name.Equals(achievementName))
            {
                achievements[i].isCompleted = !achievements[i].isCompleted;
            }
        }
        saveAchievements();
    }

    public void checkIfCompleted()
    {
        loadAchievements();
        for (int i = 0; i < achievements.Count; i++)
        {
            if (achievementScore.countbids.Count >= achievements[i].condition)
            {
                achievements[i].isCompleted = true;
            }
        }
        saveAchievements();
    }

    public void saveAchievements()
    {
        Debug
            .Log("\n\n\n\n ****************** \n\n\n\n SAVING ACHIEVEMENTS NOW \n\n\n\n ****************** \n\n\n\n");
        string filePath = Application.persistentDataPath + "/achievements.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(achievements));
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
