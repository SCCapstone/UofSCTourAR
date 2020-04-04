using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class manageAchievements : MonoBehaviour
{
    public static List<Achievement> achievements;
    //public string filePath = Application.dataPath + "/achievements.json";

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
        /*
        Debug.Log("line :"+achievements[0]);
        if (achievements.Count>1 && achievements != null) {
            Debug.Log("ohhhh yeahhhhh");
        }
        int counter=0;
        foreach (Achievement ach in achievements) {
            Debug.Log("Name "+counter+": "+ ach.name);
            Debug.Log("Name_index "+counter+": "+ achievements[counter].name);
            counter++;
        }*/
    }

    public class Achievement
    {
        public string name;
        public int condition;
        public bool isCompleted;
        public string description;
    }

    private void loadAchievements()
    {
        // JUST FILE IO
        /*
            Application.dataPath is required because it is the only way to ensure that we are accessing our assets folder,
            on both desktop runs and mobile. 
        */

        string json = Resources.Load<TextAsset>("JSON/achievements").text;
        achievements = JsonConvert.DeserializeObject<List<Achievement>>(json);
        //Debug.Log(achievements);


/*        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            achievements = JsonConvert.DeserializeObject<List<Achievement>>(json);
        }
*/
    }

    public List<Achievement> getAchievements()
    {
        // Fetch achievement list in another class
         /*
             Example of fetching list
             public static manageAchievements ach = new manageAchievements();
             private List<manageAchievements.Achievement> achievement = ach.getAchievements();
         */
        //Debug.Log(achievements);
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
        for (int i = 0; i < achievements.Count; i++)
        {
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
        //File.WriteAllText(filePath, JsonConvert.SerializeObject(achievements));
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
