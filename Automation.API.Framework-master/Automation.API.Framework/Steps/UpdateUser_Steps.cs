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
using Automation.API.Framework.BackEnd.CommonCalls.Retrieve;
using RestSharp;
using Automation.API.Framework.CommonCalls.Retrieve;
using Automation.API.Framework.BackEnd.CommonCalls.Delete;
using Automation.API.Framework.BackEnd.CommonCalls.Update;

namespace Automation.API.Framework.Steps
{
    [Binding]
    public class UpdateUser_Steps
    {
        private IRestResponse UpdateResponse;

        [Given(@"I have entered email, password to update and made a put call")]
        public void GivenIHaveEnteredEmailPasswordToUpdateAndMadeAPutCall(Table table)
        {
            
            var user = table.CreateInstance<UpdateuserwithId>();
            ScenarioContext.Current["name"] = user.name;
            ScenarioContext.Current["job"] = user.job;
            UpdateResponse =UpdateCalls.UpdateCustomer(user.id, user.name, user.job);
            //ScenarioContext.Current["response"] = UpdateResponse;
        }

        [Then(@"I should recieve valid statuscode and responsefile for updated user")]
        public void ThenIShouldRecieveValidStatuscodeAndResponsefileForUpdatedUser(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)((UpdateResponse).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");

        }



    }
}
