using NUnit.Framework;

public class MenuTest
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
    public void TestAchHome()
    {
        //Tests the menu button functions from the Achievements page
	    AltUnityDriver.LoadScene("Achievements");
        AltUnityDriver.FindElement("Menu_Button").ClickEvent();
        AltUnityDriver.WaitForElement("Sliding_Menu");
        AltUnityDriver.FindElement("Menu_Home").ClickEvent();
        AltUnityDriver.WaitForCurrentSceneToBe("HomePage");

    }
   

}