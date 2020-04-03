using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievementScore : MonoBehaviour
{

    public static List<string> countbids = new List<string>();
    public static int scoreValue = 0;
    Text score;

    public static manageAchievements ach = new manageAchievements();
    private List<manageAchievements.Achievement> achievement = ach.getAchievements();

    // Start is called before the first frame update
    void Start()
    {
        ach.checkIfCompleted();
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = countbids.Count;
        score.text = "Stops Visited:\n" + scoreValue;
    }
}
