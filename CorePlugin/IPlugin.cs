using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlugins
{

    public interface IPlugin
    {

        string GetName();

        Version GetVersion();

        List<string> AvailableMethods();

        /// <summary>
        /// Default test method for plugin
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TestResult RunTest(string parameters);

    }

}
