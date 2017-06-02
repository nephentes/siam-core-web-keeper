using AutoMapper;
using CoreHelpers.Generics;
using Microsoft.AspNetCore.Mvc;
using SiamCoreRepository.Definitions;
using SiamCoreServices;
using SiamCoreSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreSite.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private IUsersService _usersService;

        public UsersController(IUsersService usersService) : base()
        {
            _usersService = usersService;
        }

        [HttpGet("doLogin/{username}/{password}")]
        public GenericResponse<UserModel> DoLogin(string username, string password)
        {
            var retVal = new GenericResponse<UserModel>(null);
            try
            {
                var loginResult = _usersService.VerifyPassword(username, password);
                switch (loginResult.Result)
                {
                    case AdvResultCode.OK:
                        retVal.resultCode = "OK";
                        retVal.data = Mapper.Map<UserDTO, UserModel>(loginResult.Data);
                        break;
                    default:
                        retVal.resultCode = "DENY";
                        break;
                }
                retVal.isOk = true;
            }
            catch (Exception eX)
            {
                retVal.message = eX.Message;
                retVal.isOk = false;
            }
            return retVal;
        }

    }
}
