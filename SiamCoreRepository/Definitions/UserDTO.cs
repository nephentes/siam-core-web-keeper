using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiamCoreRepository.Definitions
{
    [Table("users")]
    public class UserDTO
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        [Column("pwd_hash")]
        public string PwdHash { get; set; }

        [Column("when_added")]
        public DateTime? WhenAdded { get; set;  }

        [Column("ghost")]
        public bool Ghost { get; set; }

    }

}
