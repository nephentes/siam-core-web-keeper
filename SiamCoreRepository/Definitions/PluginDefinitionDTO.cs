using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiamCoreRepository.Definitions
{

    [Table("plugins")]
    public class PluginDefinitionDTO
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("uid")]
        public string Uid { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("dll_file")]
        public string DllFile { get; set; }

        [Column("dll_method")]
        public string DllMethod { get; set; }

        [Column("ghost")]
        public bool Ghost { get; set; }

    }

}
