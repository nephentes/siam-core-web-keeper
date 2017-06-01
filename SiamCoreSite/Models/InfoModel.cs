using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SiamCoreSite.Models
{

    public class InfoModel
    {

        public DateTime ServerTime { get; set; }

        public string ServerTimeFormated { get; set; }

        public string BackendVersion { get; set; }

        public InfoModel()
        {
            ServerTime = DateTime.Now;
            ServerTimeFormated = ServerTime.ToString();
            BackendVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        }

    }

}
