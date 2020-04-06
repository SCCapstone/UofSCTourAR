﻿using NUnit.Framework;

public class AchPageLoad
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
    public void Test()
    {
        //AltUnityDriver.LoadScene("HomePage");
        Assert.Pass();
    }

}