using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreHelpers.Interfaces
{
    public interface IGhostable
    {

        bool Ghost { get; set; }

        DateTime? WhenDeleted { get; set; }

        string WhoDelete { get; set; }

    }
}
