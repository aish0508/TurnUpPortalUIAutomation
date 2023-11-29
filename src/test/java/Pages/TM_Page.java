package Pages;

import Utilies.WaitHelpers;
import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class TM_Page {
    public void CreateNewTime(WebDriver dr, String keyboard, String m, String unknownMaterial, String number) throws InterruptedException {



          WaitHelpers.WaitToBeClickable(dr, "XPath", "//*[@id=\"container\"]/p/a", 5);

        // Click on create new button
        WebElement createNewButton = dr.findElement(By.xpath("//*[@id=\"container\"]/p/a"));
        createNewButton.click();
        // Select "Time" from typecode dropdown
        Thread.sleep(1000);
        WebElement typeCodeDropdown = dr.findElement(By.xpath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.click();
        Thread.sleep(1000);
        WebElement timeOption = dr.findElement(By.xpath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.click();
        WebElement Code = dr.findElement(By.id("Code"));
        Code.sendKeys("123");
        WebElement description = dr.findElement(By.id("Description"));
        description.sendKeys("Test");
        WebElement priceperunit = dr.findElement(By.xpath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceperunit.sendKeys("34");
        Thread.sleep(1000);
        //Save time record
        WebElement SaveButton = dr.findElement(By.cssSelector("[Value='Save']"));
        SaveButton.click();


    }
    public void CreateTMAssertion(WebDriver driver, String code, String typeCode, String description, String price) {

        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        // Wait till the last page button is clickable
        WaitHelpers.WaitToBeClickable(driver, "xpath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 20);

        // Click on go to last page button
        WebElement goToLastPageButton = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        goToLastPageButton.click();

        // Check if material record has been created
        WaitHelpers.WaitToBeVisible(driver, "xpath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 20);
        WebElement newCode = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        WebElement newTypeCode = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
        WebElement newDescription = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
        WebElement newPrice = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

        Assert.assertEquals(newCode.getText(),code, "Material record hasn't been created");
        Assert.assertEquals(newTypeCode.getText(),typeCode, "Material record hasn't been created");
        Assert.assertEquals(newDescription.getText(),description, "Material record hasn't been created");
        Assert.assertEquals(newPrice.getText(),price, "Material record hasn't been created");
    }



    public void EditTMPage(WebDriver dr, String code, String description , String price, String number)
    {
        Thread.sleep(8000);
        WebElement Edit = dr.findElement(By.xpath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        Edit.click();
        Thread.sleep(1000);
        //edit code
        WebElement editCodeTextbox = dr.findElement(By.id("Code"));
        editCodeTextbox.clear();
        editCodeTextbox.sendKeys("Test");
        //Edit discription in discription text box
        WebElement editDescriptionTextbox = dr.findElement(By.id("Description"));
        editDescriptionTextbox.clear();
        editDescriptionTextbox.sendKeys("Test Description");
        //Edit price per unit in price per unit textbox

        WebElement editPriceTextbox = dr.findElement(By.xpath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        //editPriceTextbox.Clear();
        editPriceTextbox.sendKeys(price);
        //save button
        WebElement Button = dr.findElement(By.id("SaveButton"));
        Button.click();

    }
    public void DeleteTMPage(WebDriver dr) throws InterruptedException {
        Thread.sleep(3000);
        WebElement goToLastPageButtonEdit = dr.findElement(By.xpath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButtonEdit.click();
        Thread.sleep(8000);
        WebElement editedRecord = dr.findElement(By.xpath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (editedRecord.getText() == "Test")
        {
            Thread.sleep(3000);
            WebElement deleteButton = dr.findElement(By.xpath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.click();
        }
        else
        {
            Assert.fail("Record to be deleted has not been found.");
        }
        Thread.sleep(4000);

        dr.switchTo().alert().accept();


    }
    public void DeleteTMAssertion(WebDriver driver, String typeCode, String description, String price) {

        driver.navigate().refresh();

        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        // Check if material record has been updated
        WebElement updatedTypeCode = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        WebElement updatedDescription = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        WebElement updatedPrice = driver.findElement(By.xpath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

        Assert.assertNotEquals(updatedTypeCode.getText(), typeCode, "Material record hasn't been deleted");
        Assert.assertNotEquals(updatedDescription.getText(), description, "Material record hasn't been deleted");
        Assert.assertNotEquals(updatedPrice.getText(), price, "Material record hasn't been deleted");

    }
}


