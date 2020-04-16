using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.IO;
using System;
using Newtonsoft.Json;

public class sceneLoaderTest : MonoBehaviour
{
    [Test]
    public void searchForTourHistoryScene_Test()
    {
        var sceneLoader = new SearchSceneLoader();

        var sceneExists = sceneLoader.SceneExists("TourHistory");
        Assert.AreEqual(sceneExists, true);
    }
    [Test]
    public void searchForMapScene_Test()
    {
        var sceneLoader = new SearchSceneLoader();

        var sceneExists = sceneLoader.SceneExists("Map");
        Assert.AreEqual(sceneExists, true);
    }

    [Test]
    public void searchInvalidScene_Test()
    {
        var sceneLoader = new SearchSceneLoader();

        var sceneExists = sceneLoader.SceneExists("blehehahfhahah");
        Assert.AreEqual(sceneExists, false);
    }

    [Test]
    public void searchCaseInsensitive_Test()
    {
        var sceneLoader = new SearchSceneLoader();

        var sceneExists = sceneLoader.SceneExists("tourhistory");
        Assert.AreEqual(sceneExists, false);
    }

    [Test]
    public void CreateTourHistory()
    {
        var manageTH = new manageTourHistory();
    }

    [Test]
    public void ClearTourHistory()
    {
        var manageTH = new manageTourHistory();
        manageTH.addStopToHistory("rutledge", "today");
        manageTH.addStopToHistory("rutledge2", "today");
        manageTH.clearTourHistory(); //ensure that local data doesn't mess up the test
        var THobj = manageTH.getTourHistory();
        Assert.AreEqual(0, THobj.Count);
    }

    [Test]
    public void AddToTourHistory()
    {
        var manageTH = new manageTourHistory();
        manageTH.clearTourHistory(); //ensure that local data doesn't mess up the test
        manageTH.addStopToHistory("rutledge", "today");
        var THobj = manageTH.getTourHistory();
        Assert.AreEqual(1, THobj.Count);
    }

    [Test]
    public void createManageAchievements()
    {
        //Arrange
        var manager = new GameObject("manageAchievements").AddComponent<manageAchievements>();
    }

    [Test]
    public void toggleStatusOfAchievement()
    {
        //Arrange
        var manager = new GameObject("manageAchievements").AddComponent<manageAchievements>();
        manager.loadAchievements();
        manager.resetAchievements(); //ensure that local data doesn't mess up the test
        manager.toggleAchievementStatus("1st Stop!");
        //Assert
        Assert.AreEqual(manager.getAchievementStatus(0), true);
    }

    [Test]
    public void clearAchievements()
    {
        //Arrange
        var manager = new GameObject("manageAchievements").AddComponent<manageAchievements>();
        manager.loadAchievements();
        manager.resetAchievements();
        //Assert
        Assert.AreEqual(manager.getAchievementStatus(0), false);
    }
}
