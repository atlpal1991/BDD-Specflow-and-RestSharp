using Automation.API.Framework.BackEnd.CommonCalls.Create;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow.Assist;
using Automation.API.Framework.Models.RequestModel;
using Automation.API.Framework.Models.ResponseModel;
using RestSharp;

namespace Automation.API.Framework.Steps
{
    [Binding]
    public class Register_Create
    {
        [Given(@"I have entered email, password to register")]
        public void GivenIHaveEnteredEmailPasswordToRegister(Table table)
        {
            var user = table.CreateInstance<registerUser>();
            ScenarioContext.Current["email"] = user.email;
            ScenarioContext.Current["password"] = user.password;           
        }

        [When(@"made a post call to register user")]
        public void WhenMadeAPostCallToRegisterUser()
        {
            ScenarioContext.Current["response"] = RegisterCalls.RegisterUSer(ScenarioContext.Current["email"].ToString(), ScenarioContext.Current["password"].ToString());
            var response = RegisterCalls.RegisterUSer(ScenarioContext.Current["email"].ToString(), ScenarioContext.Current["password"].ToString()).Content;
        }

        [Then(@"I should recieve valid statuscode and responsefile for registered user")]
        public void ThenIShouldRecieveValidStatuscodeAndResponsefileForRegisteredUser(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)(((IRestResponse)ScenarioContext.Current["response"]).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");

            //Verifiying reponse, response must return the id of new user being registered
            if (!((IRestResponse)ScenarioContext.Current["response"]).Content.Contains("id"))
            { Assert.Fail("Whether information is not displayed"); }



        }

        [Given(@"I have entered name, job for new user")]
        public void GivenIHaveEnteredNameJobForNewUser(Table table)
        {
            var user = table.CreateInstance<createUser>();
            ScenarioContext.Current["name"] = user.name;
            ScenarioContext.Current["job"] = user.job;
        }

        [When(@"made a post call to create user")]
        public void WhenMadeAPostCallToCreateUser()
        {
            ScenarioContext.Current["response"] = CreateCalls.CreateUser(ScenarioContext.Current["name"].ToString(), ScenarioContext.Current["job"].ToString());
            var a= ((IRestResponse)ScenarioContext.Current["response"]).Content;
        }

        [Then(@"I should recieve valid statuscode and responsefile for new user")]
        public void ThenIShouldRecieveValidStatuscodeAndResponsefileForNewUser(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)(((IRestResponse)ScenarioContext.Current["response"]).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");

            // Verifiying reponse, response must return the id of new user being created
            if (!((IRestResponse)ScenarioContext.Current["response"]).Content.Contains("id"))
            { Assert.Fail("Whether information is not displayed"); }



        }


    }
}