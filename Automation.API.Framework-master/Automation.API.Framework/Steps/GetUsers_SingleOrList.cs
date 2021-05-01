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

namespace Automation.API.Framework.Steps
{
    [Binding]
    public class GetUsers_SingleOrList
    {

        private IRestResponse SingleUserResponse;
        private IRestResponse ListUserResponse;
        [Given(@"I have made a get call using id")]
        public void GivenIHaveMadeAGetCallUsingId(Table table)
        {
            var user = table.CreateInstance<SingleUser>();
            SingleUserResponse = GetSingleUser.getUser(user.id);
        }

        [Then(@"I should recieve valid statuscode and responsefile for requested user")]
        public void ThenIShouldRecieveValidStatuscodeAndResponsefileForRequestedUser(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)((SingleUserResponse).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");

            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string file = System.IO.Path.Combine(newPath, k.responsefile);

            string InstanceExpected = JObject.Parse(File.ReadAllText(file)).ToString();
            string InstanceActual = SingleUserResponse.Content;
            var InstanceObjExpected = JObject.Parse(InstanceExpected);
            var InstanceObjActual = JObject.Parse(InstanceActual);

            if (!(JToken.DeepEquals(InstanceObjExpected, InstanceObjExpected)))
            {
                Assert.Fail("Response body is different");
            }
        }

        [Given(@"I have made a get call to list all users")]
        public void GivenIHaveMadeAGetCallToListAllUsers()
        {
            ListUserResponse = GetUsersList.getUser();
        }

        [Then(@"I should recieve valid statuscode and responsefile for all user")]
        public void ThenIShouldRecieveValidStatuscodeAndResponsefileForAllUser(Table table)
        {
            var k = table.CreateInstance<responseVerification>();
            //verify status code
            int StatusCode = (int)((ListUserResponse).StatusCode);
            Assert.AreEqual(k.statuscode, StatusCode, "Status code is not as expected");



            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string file = System.IO.Path.Combine(newPath, k.responsefile);

            string InstanceExpected = JObject.Parse(File.ReadAllText(file)).ToString();
            string InstanceActual = ListUserResponse.Content;
            var InstanceObjExpected = JObject.Parse(InstanceExpected);
            var InstanceObjActual = JObject.Parse(InstanceActual);

            if (!(JToken.DeepEquals(InstanceObjExpected, InstanceObjExpected)))
            {
                Assert.Fail("Response body is different");
            }

        }




    }
}