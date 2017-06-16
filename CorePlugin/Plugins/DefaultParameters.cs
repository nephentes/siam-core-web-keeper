using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlugins.Plugins
{

    public class DefaultParameters
    {

        public string Url { get; set; }

        public string ExpectedOutput { get; set; }

        public int? WarningLimit { get; set; }

        public int? ErrorLimit { get; set; }

        public DefaultParameters()
        {

        }

    }

}
