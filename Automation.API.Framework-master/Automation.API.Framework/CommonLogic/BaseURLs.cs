using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Automation.API.Framework.BackEnd
{
    public class BaseURLs
    {
        public static string URL = "", tokenURL = "";

        internal static void SetBaseUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            var config = new ConfigurationBuilder().AddJsonFile(System.IO.Path.Combine(newPath, "AppConfig.json")).Build();

            if (testEnvironment == Envirnoment.SysTest)
            {
                URL = config["baseURLSysTest"];
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                URL = config["baseURLDev"];
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                URL = config["baseURLUAT"];
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                URL = config["baseURLPreStaging"];
            }
        }


    }
}