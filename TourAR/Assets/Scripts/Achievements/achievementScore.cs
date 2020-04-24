using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class achievementScore : MonoBehaviour
{
    public static List<string> countbids = new List<string>();

    public static int scoreValue = 0;

    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = countbids.Count;
        score.text = "Stops Visited:\n" + scoreValue;
    }

    public static void loadCountBIDS()
    {
        if (File.Exists(Application.persistentDataPath + "/countbids.json"))
        {
            string filePath = Application.persistentDataPath + "/countbids.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                countbids = JsonConvert.DeserializeObject<List<string>>(json);
            }
        }
    }

    public static void addToCountBIDS(string bID)
    {
        loadCountBIDS();
        countbids.Add(bID);
        saveCountBIDS();
    }

    private static void saveCountBIDS()
    {
        string filePath = Application.persistentDataPath + "/countbids.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(countbids));
    }
}
