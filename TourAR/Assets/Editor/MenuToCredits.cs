﻿using NUnit.Framework;

public class MenuToCredits
{
    public AltUnityDriver AltUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        AltUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        AltUnityDriver.Stop();
    }

    [Test]
    public void TestAchCredits()
    {
	    //open menu and open credits page
        AltUnityDriver.LoadScene("Achievements");
        AltUnityDriver.FindElement("Menu_Button").ClickEvent();
        AltUnityDriver.WaitForElement("Sliding_Menu");
        AltUnityDriver.FindElement("Nav_Credits").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("Credits");
    }

}