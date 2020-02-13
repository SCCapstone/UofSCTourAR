using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.IO;
using System;

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
    public void testRead()
    {
        var readPath = Application.dataPath + "/Test.txt";
        Assert.AreEqual(readFile(readPath), "thisisatest");
    }

    string readFile(string filePath) 
    {
        StreamReader sReader = new StreamReader(filePath);
        string toReturn = "";
        while(!sReader.EndOfStream) 
        {
            string line = sReader.ReadLine();
            toReturn += line;
        }

        sReader.Close();
        return toReturn;
    }

    [Test]
    public void testWrite()
    {
        var writePath = Application.dataPath + "/TestWrite.txt";
        List<string> myFile = new List<string>();
        myFile.Add("This should work \nalso noice");
        WriteFile(writePath, myFile);
    }
    
    void WriteFile(string filePath, List<string> fileToWrite) 
    {
        StreamWriter sWriter;

        if(!File.Exists(filePath)) 
        {
            sWriter = File.CreateText(Application.dataPath + "/Test.txt");
        }
        else 
        {
            sWriter = File.CreateText(filePath);
        }

        for(int i = 0; i < fileToWrite.Count; i++) 
        {
            sWriter.WriteLine(fileToWrite[i]);
        }
        sWriter.Close();
    }

    [Test]
    public void testReadJSON()
    {
        var writePath = Application.dataPath + "/TestWrite.txt";
        List<string> myFile = new List<string>();
        myFile.Add("This should work \nalso noice");
        WriteFile(writePath, myFile);
    }

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
    }

    public class TourStop
    {
        public string name;
        public boolean isVisited;
        public string description;
    }

}
