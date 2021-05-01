using Automation.Framework.Base;
using RestSharp;
using Unity;

namespace Automation.API.Framework.BackEnd.CommonCalls.Delete
{
    public class DeleteCalls
    {
        private static CommonPage _commonPage = UnityContainerFactory.GetContainer().Resolve<CommonPage>();

        //example
        public static IRestResponse DeleteCustomer(int cusID)
        {
            _commonPage.APIResponse = CommonAPICall.APICall(Method.DELETE, "api/users/" + cusID );

            return _commonPage.APIResponse;
        }
    }
}