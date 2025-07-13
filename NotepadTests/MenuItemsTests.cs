using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace NotepadTests;

[TestFixture]
public class MenuItemsTests
{
    private WindowsDriver<WindowsElement> _driver;
    private const string AppPath = @"C:\Windows\System32\notepad.exe";
    
    [SetUp]
    public void Setup()
    {
        // Initialize any required resources or state before each test
        var options = new DesiredCapabilities();
        options.SetCapability("app", AppPath);

        _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        
        Thread.Sleep(3000);
        Assert.That(_driver, Is.Not.Null, "Driver should be initialized successfully.");
    }

    [Test]
    public void MenuItemsTests_UseEditMenu_GetDateTime()
    {
        // Arrange
        // get editor page
        var editorPage = _driver.FindElementByClassName("RichEditD2DPT");
        Assert.That(editorPage, Is.Not.Null, "Editor page should be found.");
        
        // Clear the editor page
        editorPage.SendKeys(Keys.Control + "a");
        editorPage.SendKeys(Keys.Delete);
        
        // Act
        _driver.FindElementByName("Edit").SendKeys(Keys.Enter);
        _driver.FindElement(By.XPath($"//MenuItem[starts-with(@Name, \"Time/Date\")]")).Click();
        var stringDateTime = editorPage.Text;

        _driver.FindElementByName("Edit").SendKeys(Keys.Enter);
        _driver.FindElement(By.XPath($"//MenuItem[starts-with(@Name, \"Select all\")]")).SendKeys(Keys.Enter);
        
        _driver.FindElementByName("Edit").SendKeys(Keys.Enter);
        _driver.FindElement(By.XPath($"//MenuItem[starts-with(@Name, \"Copy\")]")).SendKeys(Keys.Enter);
        
        _driver.FindElementByName("Edit").SendKeys(Keys.Enter);
        _driver.FindElement(By.XPath($"//MenuItem[starts-with(@Name, \"Paste\")]")).SendKeys(Keys.Enter);
        
        _driver.FindElementByName("Edit").SendKeys(Keys.Enter);
        _driver.FindElement(By.XPath($"//MenuItem[starts-with(@Name, \"Paste\")]")).SendKeys(Keys.Enter);

        // Assert
        Assert.That(stringDateTime + stringDateTime, Is.EqualTo(editorPage.Text), 
            "The date and time should be inserted twice in the editor page.");
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            _driver.Close();
        }
        catch
        {
        }
        
        _driver.Quit();
        _driver = null;
    }
}