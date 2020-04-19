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
        Debug
            .Log("\n\n\n\n ****************** \n\n\n\n LOADING COUNT B IDS \n\n\n\n ****************** \n\n\n\n");
        if (File.Exists(Application.persistentDataPath + "/countbids.json"))
        {
            Debug
                .Log("\n\n\n\n ****************** \n\n\n\n FOUND countbids.json IN PERSISTENT STORAGE \n\n\n\n ****************** \n\n\n\n");
            string filePath =
                Application.persistentDataPath + "/countbids.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                countbids = JsonConvert.DeserializeObject<List<string>>(json);
            }
        }
        else
        {
            Debug
                .Log("\n\n\n\n ****************** \n\n\n\n DID NOT FIND countbids.JSON IN PERSISTENT STORAGE \n\n\n\n ****************** \n\n\n\n");
        }
    }

    public static void addToCountBIDS(string bID)
    {
        loadCountBIDS();
        Debug
            .Log("\n\n\n\n ****************** \n\n\n\n ADD TO COUNT BIDS CALLED \n\n\n\n ****************** \n\n\n\n");
        countbids.Add (bID);
        saveCountBIDS();
    }

    private static void saveCountBIDS()
    {
        Debug
            .Log("\n\n\n\n ****************** \n\n\n\n SAVING COUNT BIDS NOW \n\n\n\n ****************** \n\n\n\n");
        string filePath = Application.persistentDataPath + "/countbids.json";
        File.WriteAllText(filePath, JsonConvert.SerializeObject(countbids));
    }
}
