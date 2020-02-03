public enum By
{
    TAG, LAYER, NAME, COMPONENT, PATH, ID
}

public class BaseFindObjects : CommandReturningAltElement
{
    public BaseFindObjects(SocketSettings socketSettings) : base(socketSettings)
    {
    }
    protected string SetPath(By by, string value)
    {
        string path = "";
        switch (by)
        {
            case By.TAG:
                path = "//*[@tag=" + value + "]";
                break;
            case By.LAYER:
                path = "//*[@layer=" + value + "]";
                break;
            case By.NAME:
                path = "//" + value;
                break;
            case By.COMPONENT:
                path = "//*[@component=" + value + "]";
                break;
            case By.PATH:
                path = value;
                break;
            case By.ID:
                path = "//*[@id=" + value + "]";
                break;
        }
        return path;
    }
    protected string SetPathContains(By by, string value)
    {
        string path = "";
        switch (by)
        {
            case By.TAG:
                path = "//*[contains(@tag," + value + ")]";
                break;
            case By.LAYER:
                path = "//*[contains(@layer," + value + ")]";
                break;
            case By.NAME:
                path = "//*[contains(@name," + value + ")]";
                break;
            case By.COMPONENT:
                path = "//*[contains(@component," + value + ")]";
                break;
            case By.PATH:
                path = value;
                break;
            case By.ID:
                path = "//*[contains(@id," + value + ")]";
                break;
        }
        return path;
    }
}