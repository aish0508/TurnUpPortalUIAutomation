using Login.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Turnup.Utilis;

namespace Turnup.StepDefinition
{
    public class TMFeatureStepDefinition:CommonDriver
    {
            
        TMPage tmPageObject = new TMPage();
        HomePage homePageObj = new HomePage();
        LoginPage loginPageObj = new LoginPage();

        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //Open Chrome browser
            dr = new ChromeDriver();

            // Login page object initialization and definition

            loginPageObj.LoginActions(dr);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and deifinition

            homePageObj.GoToTMPage(dr);
        }

        [When(@"I create a new time record")]
        public void WhenICreateANewTimeRecord()
        {


            tmPageObject.CreateNewTime(dr);
        }
        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {


            string newCode = tmPageObject.GetCode(dr);
            string newDescription = tmPageObject.GetDescription(dr);
            string newPrice = tmPageObject.GetPrice(dr);

            Assert.That(newCode == "October2023", "New code and expected code do not match.");
            Assert.That(newDescription == "October2023", "New description and expected description do not match.");
            Assert.That(newPrice == "$12.00", "New price and expected price do not match.");
        }
        [When(@"I update the '([^']*)', '([^']*)' and '([^']*)' of an existing time record")]
        public void WhenIUpdateTheAndOfAnExistingTimeRecord(string code, string description, string price)
        {
            tmPageObject.EditTMPage(dr, code, description, price);
        }

        [Then(@"the record should have an updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveAnUpdatedAnd(string code, string description, string price)
        {
            string editedCode = tmPageObject.GetCode(dr);
            string editedDescription = tmPageObject.GetDescription(dr);
            string editedPrice = tmPageObject.GetPrice(dr);

            Assert.That(editedCode, Is.EqualTo(code), "Actual and expected Code do not match.");
            Assert.That(editedDescription, Is.EqualTo(description), "Actual and expected Description do not match.");
            Assert.That(editedPrice, Is.EqualTo(price), " Actual and expected Price do not match.");
        }
    }
}
