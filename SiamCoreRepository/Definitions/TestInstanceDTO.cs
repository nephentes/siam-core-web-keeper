using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiamCoreRepository.Definitions
{
    [Table("test_instances")]
    public class TestInstanceDTO
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public int Name { get; set; }

        [Column("description")]
        public int Description { get; set; }

        [Column("id_plugin")]
        public PluginDefinitionDTO Plugin { get; set; }

        [Column("parameters")]
        public string Parameters { get; set; }

        [Column("timing")]
        public string Timing { get; set; }

        [Column("last_run")]
        public DateTime? LastRun { get; set; }

        [Column("next_run")]
        public DateTime? NextRun { get; set; }

        [Column("when_added")]
        public DateTime? WhenAdded { get; set; }

        [Column("when_deleted")]
        public DateTime? WhenDeleted { get; set; }

        [Column("ghost")]
        public bool Ghost { get; set; }

    }

}
