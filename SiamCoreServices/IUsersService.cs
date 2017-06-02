using CoreHelpers.Templates;
using SiamCoreRepository.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiamCoreServices
{

    public interface IUsersService
    {

        ComplexResult<AdvResultCode, UserDTO> VerifyPassword(string login, string password);

        AdvResultCode CreateUser(string login, string password);

    }

}
