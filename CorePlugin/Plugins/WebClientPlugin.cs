using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CorePlugins.Plugins
{
    public class WebClientPlugin : IPlugin
    {

        public string GetName()
        {
            return "WebClientPlugin";
        }

        public Version GetVersion()
        {
            return new Version(1, 0);
        }

        public List<string> AvailableMethods()
        {
            return new List<string> { "RunTest" };
        }

        public static HttpClient httpClient = new HttpClient();

        public TestResult RunTest(string parameters)
        {
            TestResult retVal = new TestResult();
            try
            {
                var param = JsonConvert.DeserializeObject<DefaultParameters>(parameters);

                var startDate = DateTime.Now;
                var getStringTask = httpClient.GetStringAsync(param.Url);
                getStringTask.Wait();
                var resultString = getStringTask.Result;
                var endDate = DateTime.Now;

                var tookMs = (endDate - startDate).Milliseconds;

                if (resultString.ToLower().Contains(param.ExpectedOutput.ToLower()))
                {
                    retVal.Result = ResultCode.normal;

                    if (param.WarningLimit.HasValue && param.WarningLimit.Value < tookMs)
                        retVal.Result = ResultCode.warning;

                    if (param.ErrorLimit.HasValue && param.ErrorLimit.Value < tookMs)
                        retVal.Result = ResultCode.error;

                }
                else
                {
                    retVal.Result = ResultCode.error;
                }

                retVal.Result = ResultCode.error;
            }
            catch (Exception ex)
            {
                retVal.Result = ResultCode.fatal;
                retVal.Message = ex.Message;
            }
            return retVal;
        }

    }
}
