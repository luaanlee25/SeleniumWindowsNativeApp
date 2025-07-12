import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.net.URI;
import java.util.concurrent.TimeUnit;
import java.net.URL;
import io.appium.java_client.windows.WindowsDriver;

public class SpotifyTests {

    private static WindowsDriver driver;

    @BeforeEach
    public void setup() {


    }

    @Test
    public void SpotifyLaunchTest(){
        driver.quit();
    }
}
