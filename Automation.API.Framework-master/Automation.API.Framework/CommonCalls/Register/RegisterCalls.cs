using Automation.API.Framework.Models.RequestModel;
using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Create
{
    internal class RegisterCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse RegisterUSer(string email, string password)
        {
            string queryBody;

            registerUser cus = new registerUser();

            cus.email = email;
            cus.password = password;

            queryBody = SimpleJson.SerializeObject(cus);

            _commonPage.APIResponse = CommonAPICall.APICall(Method.POST, "api/register", queryBody);

            return _commonPage.APIResponse;
        }
    }
}