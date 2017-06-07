using CoreHelpers.Templates;
using SiamCoreRepository.Definitions;
using SiamCoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreServices
{

    public interface ICoreSession
    {

        UserToken CreateToken(UserDTO user);

        ComplexResult<bool, UserToken> CheckToken(string token, bool silent = false);

    }

}
