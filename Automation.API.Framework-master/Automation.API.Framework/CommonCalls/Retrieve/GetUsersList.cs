using Automation.API.Framework.BackEnd;
using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.CommonCalls.Retrieve
{
    public class GetUsersList
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse getUser()
        {
            return CommonAPICall.APICall(Method.GET, "api/users?page=2");
        }
    }
}
