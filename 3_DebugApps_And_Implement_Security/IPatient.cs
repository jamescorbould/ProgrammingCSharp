using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DebugApps_And_Implement_Security
{
    interface IPatient
    {
        string GHNumber { get; set; }
        string Name { get; set; }
        string Age { get; set; }
        System.Guid DoBulkLoad();
    }
}
