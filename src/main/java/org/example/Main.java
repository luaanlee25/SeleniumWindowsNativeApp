package org.example;

import io.appium.java_client.windows.WindowsDriver;
import io.appium.java_client.windows.options.WindowsOptions;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import java.net.URL;
import java.util.concurrent.TimeUnit;

public class Main {
    public static void main(String[] args) {
        // Check
        try{
            var options = new WindowsOptions()
                    .setApp("C:\\Windows\\System32\\notepad.exe") // prefer to use path to application, instead the app id
                    .setAutomationName("windows")
                    .setPlatformName("windows");
            options.setCapability("ms:waitForAppLaunch", "20"); // lưu ý ở giá trị này, nên để lâu, vì appium ko detect được app nên sẽ mở instance khác.

            WindowsDriver driver = new WindowsDriver(new URL("http://127.0.0.1:4723"), options);
            driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
            driver.manage().window().maximize();

            driver.findElement(By.name("Text editor")).sendKeys("Noi dung duoc tao tu dong, se xoa trong 2 giay nua.");
            Thread.sleep(2000);


            driver.findElement(By.name("Text editor")).sendKeys(Keys.CONTROL + "a");
            driver.findElement(By.name("Text editor")).sendKeys(Keys.DELETE);

            Thread.sleep(2000);

            driver.quit();
        }
        catch (Exception e){
            e.printStackTrace();
        } finally { }
    }
}