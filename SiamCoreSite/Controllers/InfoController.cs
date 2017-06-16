using Microsoft.AspNetCore.Mvc;
using SiamCoreSite.Models;

namespace SiamCoreSite.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {

        [HttpGet("version/{token}")]
        public InfoModel Get(string token)
        {
            var retVal = new InfoModel();

            return retVal;
        }


        [HttpGet("dojobs")]
        public string DoJobs()
        {
            //var nextTab = NCrontab.CrontabSchedule.Parse("");
            //nextTab.GetNextOccurrence()
            return "OK";
        }

    }
}
