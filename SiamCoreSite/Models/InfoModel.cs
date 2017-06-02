using System;
using System.Reflection;


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
