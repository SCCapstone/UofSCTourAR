using NUnit.Framework;

public class AchToSearch
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
    public void TestAchSearch()
    {
	    //open search 
        AltUnityDriver.LoadScene("Achievements");
        AltUnityDriver.FindElement("Search_Button (2)").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("Search");
    }

}