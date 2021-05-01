using Automation.API.Framework.Models.RequestModel;
using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Create
{
    internal class CreateCalls
    {
       // private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse CreateUser(string name, string job)
        {
            string queryBody;

            createUser cus = new createUser();

            cus.name = name;
            cus.job = job;

            queryBody = SimpleJson.SerializeObject(cus);

            return CommonAPICall.APICall(Method.POST, "api/users", queryBody);
        }
    }
}