using AutoMapper;
using CoreHelpers.Generics;
using Microsoft.AspNetCore.Mvc;
using SiamCoreRepository;
using SiamCoreRepository.Definitions;
using SiamCoreServices;
using SiamCoreServices.Models;
using SiamCoreSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreSite.Controllers
{
    [Route("api/[controller]")]
    public class PluginsController : Controller
    {

        private readonly IUsersService _usersService;

        private readonly ICoreSession _core;

        public PluginsController(IUsersService usersService, ICoreSession core) : base()
        {
            _usersService = usersService;
            _core = core;
        }

        [HttpGet("list/{token}")]
        public GenericResponse<List<string>> ListPlugins(string token)
        {
            var retVal = new GenericResponse<List<string>>(new List<string>());

            if (token.Equals("qwerty"))
            {
                try
                {
                    InitializeService.InitializeDatabase(_usersService, new BaseDAL());
                    retVal.resultCode = "OK";
                    retVal.isOk = true;
                }
                catch (Exception eX)
                {
                    retVal.message = eX.Message;
                }
            }
            else
            {
                retVal.resultCode = "BAD_TOKEN";
            }

            return retVal;
        }

  

    }
}
