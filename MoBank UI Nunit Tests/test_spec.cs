using System;
using MoBankUI;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace specflowSelenium
{
    [Binding]
    public class MoShopSteps
    {
        [Given(@"I have an User Name And Password")]
        public void GivenIHaveAnUserNameAndPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"when I enter the correct Details")]
        public void GivenWhenIEnterTheCorrectDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I clikc Logon Button")]
        public void WhenIClikcLogonButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should Moshop Console HomePage")]
        public void ThenTheResultShouldMoshopConsoleHomePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
