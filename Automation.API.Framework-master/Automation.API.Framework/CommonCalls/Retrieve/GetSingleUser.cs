using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Retrieve
{
    public class GetSingleUser
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse  getUser(int cusID)
        {
            return CommonAPICall.APICall(Method.GET, "api/users/" + cusID);
        }
    }
}