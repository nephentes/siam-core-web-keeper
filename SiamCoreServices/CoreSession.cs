using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiamCoreRepository.Definitions;
using SiamCoreServices.Models;
using CoreHelpers.Templates;

namespace SiamCoreServices
{
    public class CoreSession : ICoreSession
    {

        private SortedList<string, UserToken> Tokens { get; set; } // sorted list because i want to fast searching by token uid

        public CoreSession()
        {
            Tokens = new SortedList<string, UserToken>();
        }

        public ComplexResult<bool, UserToken> CheckToken(string token, bool silent = false)
        {
            ComplexResult<bool, UserToken> retVal = new ComplexResult<bool, UserToken>();

            lock (Tokens)
            {
              
                if (Tokens.ContainsKey(token))
                {
                    var tokenForUid = Tokens[token];
                    if (tokenForUid.IsValid)
                    {
                        if (!silent)
                            tokenForUid.LastAction = DateTime.Now;

                        retVal.Data = tokenForUid;
                        retVal.Result = true;
                    }
                    else
                    {
                        retVal.Result = false; // or it is invalid so too old
                    }
                }
                else
                {
                    retVal.Result = false;  // there is no such token
                }
            }
            return retVal;
        }

        public UserToken CreateToken(UserDTO user)
        {
            lock (Tokens)
            {
                var tokenForUser = Tokens.Values.ToList().FindLast(t => t.User.Id == user.Id);
                if (tokenForUser != null)
                    Tokens.Remove(tokenForUser.Uid); // so first we should remove previous token for given user

                var retVal = new UserToken(user); // now we can create new shiny token
                Tokens.Add(retVal.Uid, retVal);
                return retVal;
            }
        }

    }
}
