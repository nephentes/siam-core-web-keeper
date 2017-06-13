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
    public class UsersController : Controller
    {

        private readonly IUsersService _usersService;

        private readonly ICoreSession _core;

        public UsersController(IUsersService usersService, ICoreSession core) : base()
        {
            _usersService = usersService;
            _core = core;
        }

        [HttpGet("init/{token}")]
        public GenericResponse<bool> InitDatabase(string token)
        {
            var retVal = new GenericResponse<bool>(false);

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
                        // let's create token :)
                        var tokenForUser = _core.CreateToken(loginResult.Data);
                        retVal.resultCode = "OK";
                        retVal.data = Mapper.Map<UserDTO, UserModel>(loginResult.Data);
                        retVal.data.currentToken = tokenForUser.Uid;
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

        [HttpGet("checkToken/{token}")]
        public GenericResponse<TokenModel> CheckToken(string token)
        {
            var retVal = new GenericResponse<TokenModel>(null);
            try
            {
                var checkResult = _core.CheckToken(token);
                
                if (checkResult.Result)
                {
                    retVal.data = Mapper.Map<UserToken, TokenModel>(checkResult.Data);
                    retVal.data.currentToken = checkResult.Data.Uid;
                    retVal.data.login = checkResult.Data.User.Login;
                    retVal.resultCode = "OK";
                } else
                {
                    retVal.resultCode = "RELOGIN";
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
