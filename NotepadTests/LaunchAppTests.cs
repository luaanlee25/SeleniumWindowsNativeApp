using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace NotepadTests;

[TestFixture]
public class LaunchAppTests
{
    private WindowsDriver _driver;
    private const string AppPath = @"C:\Windows\System32\notepad.exe";
    
    [SetUp]
    public void Setup()
    {
        // Initialize any required resources or state before each test
        var options = new AppiumOptions
        {
            App = AppPath,
            AutomationName = "Windows",
            PlatformName = "Windows",
            DeviceName = "WindowsPC",
        };
        _driver = new WindowsDriver(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        
        Thread.Sleep(3000);
        Assert.That(_driver, Is.Not.Null, "Driver should be initialized successfully.");
    }

    [Test]
    public void LaunchAppTests_OpenFullScreen()
    {
        // Arrange
        var width = ScreenHelper.GetScreenWidth();
        var height = ScreenHelper.GetScreenHeight() - ScreenHelper.GetTaskbarHeight();
        
        // Act
        _driver.Manage().Window.Maximize();
        Thread.Sleep(1000);
        
        // Assert
        var windowSize = _driver.Manage().Window.Size;
        Assert.Multiple(() =>
        {
            Assert.That(windowSize.Height, Is.GreaterThanOrEqualTo(height), "Window height should be at least the screen height.");
            Assert.That(windowSize.Width, Is.GreaterThanOrEqualTo(width), "Window width should be at least the screen width.");
        });
    }


    [TearDown]
    public void TearDown()
    {
        _driver.CloseApp();
        _driver.Dispose();
    }
}