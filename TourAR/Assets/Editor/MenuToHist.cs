using NUnit.Framework;

public class MenuToHist
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
    public void TestAchHist()
    {
	    //open menu and open history page
        AltUnityDriver.LoadScene("Achievements");
        AltUnityDriver.FindElement("Menu_Button").ClickEvent();
        AltUnityDriver.WaitForElement("Sliding_Menu");
        AltUnityDriver.FindElement("Nav_History").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("TourHistory");
    }

}