using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
