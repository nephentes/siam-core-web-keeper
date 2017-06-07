using SiamCoreRepository.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreServices.Models
{

    public class UserToken
    {

        public string Uid { get; set; }

        public UserDTO User { get; set; }

        public DateTime? WhenCreated { get; set; }

        public DateTime? ValidUntil { get; set; }

        public DateTime? LastAction { get; set; }

        public bool IsValid
        {
            get
            {
                return DateTime.Now < ValidUntil.Value;
            }
        }

        public UserToken()
        {

        }

        public UserToken(UserDTO user) : this()
        {
            Uid = Guid.NewGuid().ToString("N");
            User = user;
            WhenCreated = DateTime.Now;
            ValidUntil = DateTime.Now.AddHours(2);
        }

    }

}
