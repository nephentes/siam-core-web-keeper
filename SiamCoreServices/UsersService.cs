using CoreHelpers;
using CoreHelpers.Templates;
using SiamCoreRepository;
using SiamCoreRepository.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiamCoreServices
{

    public class UsersService : IUsersService
    {

        private readonly IBaseDAL _baseDAL;

        private readonly ICoreSession _core;

        public UsersService(IBaseDAL baseDAL, ICoreSession core)
        {
            _baseDAL = baseDAL;
            _core = core;
        }

        public ComplexResult<AdvResultCode, UserDTO> VerifyPassword(string login, string password)
        {
            var retVal = new ComplexResult<AdvResultCode, UserDTO>();

            var usersWithThatLogin = _baseDAL.SelfContext.Users.Where(s => s.Login == login);
            if (usersWithThatLogin.Count() > 0)
            {
                var user = usersWithThatLogin.First();
                if (user.PwdHash == ShaHelper.GetHash(user.Salt + password))
                {

                    retVal.Result = AdvResultCode.OK;
                    retVal.Data = user;
                }
                else
                {
                    retVal.Result = AdvResultCode.Deny;
                }
            }
            else
            {
                retVal.Result = AdvResultCode.DontExists;
            }

            return retVal;
        }

        public AdvResultCode CreateUser(string login, string password)
        {
            var usersWithThatLogin = _baseDAL.SelfContext.Users.Where(s => s.Login == login);
            if (usersWithThatLogin.Count() == 0)
            {
                var newUser = new UserDTO()
                {
                    Login = login,
                    Ghost = false,
                    WhenAdded = DateTime.Now,
                    Salt = Guid.NewGuid().ToString("N")
                };

                var userInXml = newUser.SerializeObject();

                UserDTO deserializedUser = userInXml.DeserializeObject<UserDTO>() as UserDTO;

                newUser.PwdHash = ShaHelper.GetHash(newUser.Salt + password);

                _baseDAL.SelfContext.Users.Add(newUser);

                _baseDAL.SelfContext.SaveChanges();

                return AdvResultCode.OK;
            }
            else
            {
                return AdvResultCode.AlreadyExists;
            }
          
        }

    }

    public enum AdvResultCode
    {
        NotOK = 0,
        OK = 1,
        Deny = 2,
        AlreadyExists = 10,
        DontExists = 11
    }

}
