package Utilies;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.time.Duration;

public class WaitHelpers {
    public static void WaitToBeClickable(WebDriver dr, String locatorType, String locatorValue, int seconds)
    {
        var wait = new WebDriverWait(dr, Duration.ofSeconds(seconds));
        if (locatorType == "xpath")
        {
            wait.until(ExpectedConditions.elementToBeClickable(By.xpath(locatorValue)));
        }
        if (locatorType == "Id")
        {
            wait.until(ExpectedConditions.elementToBeClickable(By.id(locatorValue)));
        }
        if (locatorType == "CssSelector")
        {
            wait.until(ExpectedConditions.elementToBeClickable(By.cssSelector(locatorValue)));
        }
        if (locatorType == "Class")
        {
            wait.until(ExpectedConditions.elementToBeClickable(By.className(locatorValue)));
        }

    }





    public static void WaitToBeVisible(WebDriver dr,String locator,String locatorType, String locatorValue, int seconds) {
        var wait = new WebDriverWait(dr, Duration.ofSeconds(seconds));

        if (locator == "xpath") {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(locatorValue)));
        }

        if (locator == "Id") {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.id(locatorValue)));
        }

        if (locator == "CssSelector") {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector(locatorValue)));
        }
    }
}
