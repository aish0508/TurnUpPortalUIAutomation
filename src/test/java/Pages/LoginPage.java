package Pages;

import Utilies.WaitHelpers;
import org.jetbrains.annotations.NotNull;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Wait;

public class LoginPage {
    public void LoginActions(WebDriver dr) throws InterruptedException {

        dr.manage().window().maximize();
        dr.navigate().to("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        Thread.sleep(5000);
        WaitHelpers. WaitToBeVisible(dr, "Id", "UserName", 8);
        WebElement Username = dr.findElement(By.id("UserName"));
        Username.sendKeys("hari");
        WebElement Password = dr.findElement(By.id("Password"));
        Password.sendKeys("123123");
        Thread.sleep(1000);
        //Identify login button and click on the button
        WebElement loginButton = dr.findElement(By.xpath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.click();

    }
}
