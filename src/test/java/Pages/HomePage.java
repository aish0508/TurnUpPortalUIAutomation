package Pages;

import Utilies.WaitHelpers;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class HomePage {
    public void GoToTMPage(WebDriver dr) throws InterruptedException {
        Thread.sleep(4000);
        WebElement administration = dr.findElement(By.xpath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administration.click();
        WaitHelpers.WaitToBeVisible(dr, "xpath", "//*[@id='logoutForm']/ul/li/a", 15);
        WebElement TM = dr.findElement(By.xpath("//*/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        TM.click();
    }
}
