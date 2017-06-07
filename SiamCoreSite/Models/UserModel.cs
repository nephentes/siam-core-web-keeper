using System;

namespace SiamCoreSite.Models
{

    public class UserModel
    {

        public string login { get; set; }

        public DateTime? whenAdded { get; set; }

        // for now here
        public string currentToken { get; set; }

    }

}