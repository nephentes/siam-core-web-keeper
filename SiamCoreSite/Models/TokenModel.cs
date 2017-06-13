using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreSite.Models
{
    public class TokenModel
    {

        public string login { get; set; }

        public string currentToken { get; set; }

        public DateTime? validUntil { get; set; }

    }
}
