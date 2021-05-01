using Automation.API.Framework.Models.RequestModel;
using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Update
{
    public class UpdateCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse UpdateCustomer(int cusId, string name, string job)
        {
            string queryBody;

            Updateuser cus = new Updateuser();

           cus.name = name;
           cus.job = job;

            queryBody = SimpleJson.SerializeObject(cus);

            _commonPage.APIResponse = CommonAPICall.APICall(Method.PUT, "api/users/" + cusId, queryBody);

            return _commonPage.APIResponse;
        }
    }
}