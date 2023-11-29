package Tests;

import Pages.HomePage;
import Pages.LoginPage;
import Pages.TM_Page;
import Utilies.CommonDriver;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeTest;

public class TM_Tests extends CommonDriver {


        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TM_Page tmPageObj = new TM_Page();

        @BeforeTest
        public void TM_SetUp() throws InterruptedException {
            // open Chrome browser
            dr = new ChromeDriver();
            Thread.sleep(1000);

            // Login page object initialization and definition

            loginPageObj.LoginActions(dr);

            // Home page object intialization and definition

            homePageObj.GoToTMPage(dr);
        }

        @Test(priority=0, description = " This test checks if a user is able to create a new time record")
        public void CreateTime_Test() throws InterruptedException {
            // TM page object initialization and definition

            tmPageObj.CreateNewTime(dr, "Keyboard", "M","Unknown Material","500");
            tmPageObj.CreateTMAssertion(dr, "Keyboard", "M","Unknown Material","$500.00");
        }

        @Test(priority = 1, description = "This test checks if a user is able to edit an existing time record")
        public void EditTime_Test()
        {
            tmPageObj.EditTMPage(dr, "Mouse", "M","Known Material","100");
            tmPageObj.EditTMPage(dr,"Mouse", "M","Known Material","100");
        }

        @Test(priority = 2, description = "This test checks if a user is able to delete an existing time record")
        public void DeleteTime_Test() throws InterruptedException {
            tmPageObj.DeleteTMPage(dr);
            tmPageObj.DeleteTMAssertion(dr,"M","Know Material","100");
        }

        @AfterTest
        public void ClosingSteps()
        {
            dr.quit();
        }
    }

