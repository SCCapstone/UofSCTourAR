using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageAchievements : MonoBehaviour
{
    public static List<Achievement> achievements;

    /*
        Suggested Workflow:
          - Create an instance of manageAchievements, which will load data from the JSON.
          - To add a manage an achievements status:
            - call toggleAchievementStatus()
            - IMPORTANT: call saveAchievements() otherwise any changes will not actually update the JSON file.
    */
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
        // JUST FILE IO
        string json = Resources.Load<TextAsset>("JSON/achievements").text;
        achievements = JsonConvert.DeserializeObject<List<Achievement>>(json);
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

    public void checkIfCompleted() {
        for (int i = 0; i < achievements.Count; i++) {
            if (achievementScore.countbids.Count >= achievements[i].condition) {
                achievements[i].isCompleted = true;
            }
        }
        saveAchievements();
    }

/*    public void addAchievement(string aName, int condition, bool completion, string desc)
    {
        Achievement a = new Achievement();
        a.name = aName;
        a.condition = condition;
        a.isCompleted = completion;
        a.description = desc;
        achievements.Insert(0, a);
    }
*/

    public void saveAchievements()
    {
        //THIS METHOD NEEDS TO BE CALLED TO UPDATE THE JSON FILE
        File.WriteAllText("Assets/Resources/JSON/achievements.json", JsonConvert.SerializeObject(achievements));
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
