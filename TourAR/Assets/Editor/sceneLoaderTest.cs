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
        manageTH.addStopToHistory("rutledge");
        manageTH.addStopToHistory("rutledge2");
        manageTH.clearTourHistory(); //ensure that local data doesn't mess up the test
        var THobj = manageTH.getTourHistory();
        Assert.AreEqual(0, THobj.Count);
    }

    [Test]
    public void AddToTourHistory()
    {
        var manageTH = new manageTourHistory();
        manageTH.clearTourHistory(); //ensure that local data doesn't mess up the test
        manageTH.addStopToHistory("rutledge");
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

    [Test]
    public void createLoadTourStops()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
    }

    [Test]
    public void getNameOfTourStopWithID()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
        manager.prepForTests();
        var title = manager.getTitleForTourStop("rutledgeCollege");
        //Assert
        Assert.AreEqual(title, "Rutledge College");
    }

    [Test]
    public void getTitleOfInvalidStopWithID()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
        manager.prepForTests();
        var title = manager.getTitleForTourStop("invalidTourStop");
        //Assert
        Assert.AreEqual(title, "n/a no match found for this building ID");
    }

    [Test]
    public void getTourStopMeta()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
        manager.prepForTests();
        var meta = manager.getMetadataForTourStop("rutledgeCollege");
        String[] separator = {"\n\n"};
        var pieces = meta.Split(separator, 3, StringSplitOptions.RemoveEmptyEntries);
        //Assert
        Assert.AreEqual(pieces[0], "<b>Constructed:</b> 1805");
        Assert.AreEqual(pieces[1], "<b>Location:</b> Rutledge College, Columbia, SC 29208");
        Assert.AreEqual(pieces[2], "<b>Description:</b> The very first building constructed for South Carolina College, originally known as South Building, opened its doors in 1805. It contained a dormitory, lecture hall, chapel and library. In 1855, a fire severly destroyed the original elements of the chapel and the west wing of the building and was subsequently rebuilt. When the university was desegregated between 1873 and 1877, this building housed the State Normal School for Teachers, a program that trained African Americans to become teachers. The building is currently used for student dormitories, and the renovated chapel is available for rentals.");
    }

    [Test]
    public void getTourStopDescription()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
        manager.prepForTests();
        var desc = manager.getStopDescription("Thomas Cooper Library");
        //Assert
        Assert.AreEqual(desc, "Thomas Cooper Library, constructed in 1976, is the home of the University Libraries. Here, students can rent books, reserve study space, and browse special collections of maps, art, music, manuscripts and more.");
    }

    [Test]
    public void getInvalidTourStopDescription()
    {
        //Arrange
        var manager = new GameObject("loadTourStops").AddComponent<loadTourStops>();
        manager.prepForTests();
        var desc = manager.getStopDescription("invalidTourStop");
        //Assert
        Assert.AreEqual(desc, "n/a couldn't find a match");
    }
}
