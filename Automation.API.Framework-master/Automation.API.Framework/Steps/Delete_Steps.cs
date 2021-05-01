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

namespace Automation.API.Framework.Steps
{
    [Binding]
    class Delete_Steps
    {

        private IRestResponse DeleteUserResponse;
        private IRestResponse ListUserResponse;

        [Given(@"I have made a get call using id to delete a user")]
        public void GivenIHaveMadeAGetCallUsingIdToDeleteAUser(Table table)
        {
            var user = table.CreateInstance<SingleUser>();
            DeleteUserResponse = DeleteCalls.DeleteCustomer(user.id);
        }

        [Then(@"I should recieve valid statuscode as below")]
        public void ThenIShouldRecieveValidStatuscodeAsBelow(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)((DeleteUserResponse).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");
        }

    }
}
